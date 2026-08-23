using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application
{
    public class MessageService(IMessageRepository messageRepository,IUserRepository userRepository,IDeliveryRequestRepository deliveryRequestRepository,IClientRepository clientRepository,IDeliveryManRepository deliveryManRepository,IUnitOfWork unitOfWork,IHubContext<MessageHub> hubContext) : IMessageService
    {
        public async Task<BaseResponse<AddMessageResponseModel>> AddMessage(AddMessageRequestModel message)
        {
            try
            {
                var sender = await userRepository.Get(message.SenderUserId);
                var reciever = await userRepository.Get(message.RecieverUserId);
                if (sender == null || reciever == null)
                {
                    return BaseResponse<AddMessageResponseModel>.Fail("User not found");
                }
                if (sender.Role == reciever.Role)
                {
                    return BaseResponse<AddMessageResponseModel>.Fail("The application does not allow users with the same role to message each other.");
                }
                if (sender.Role == AppStatics.ClientRole && reciever.Role == AppStatics.DeliveryManRole)
                {
                    var client = await clientRepository.GetByUserId(sender.Id);
                    var deliveryMan = await deliveryManRepository.GetByUserId(reciever.Id);
                    var requessts = await deliveryRequestRepository.GetByCustomerId(client!.UserId);
                    if (requessts.Any(x => x.Delivery.DeliveryManId == deliveryMan!.Id && !x.Delivery.HasDelivered))
                    {
                        var m = new Message(message.Content, sender.Id, reciever.Id, sender.Id.ToString());
                        await messageRepository.Add(m);
                        await unitOfWork.SaveChanges();
                        await hubContext.Clients.User(m.RecieverUserId.ToString()).SendAsync("ReceiveMessage", m);
                        return BaseResponse<AddMessageResponseModel>.Sucess(new AddMessageResponseModel(m.Id));

                    }
                    return BaseResponse<AddMessageResponseModel>.Fail("The system doesn't allow message btw users if there isn't a deal btw them");
                }
                if (sender.Role == AppStatics.DeliveryManRole && reciever.Role == AppStatics.ClientRole)
                {
                    var client = await clientRepository.GetByUserId(reciever.Id);
                    var deliveryMan = await deliveryManRepository.GetByUserId(sender.Id);
                    var requessts = await deliveryRequestRepository.GetByCustomerId(client!.UserId);
                    if (requessts.Any(x => x.Delivery.DeliveryManId == deliveryMan!.Id && !x.Delivery.HasDelivered))
                    {
                        var m = new Message(message.Content, sender.Id, reciever.Id, sender.Id.ToString());
                        await messageRepository.Add(m);
                        await unitOfWork.SaveChanges();
                        await hubContext.Clients.User(m.RecieverUserId.ToString()).SendAsync("ReceiveMessage", m);

                        return BaseResponse<AddMessageResponseModel>.Sucess(new AddMessageResponseModel(m.Id));

                    }
                    return BaseResponse<AddMessageResponseModel>.Fail("The system doesn't allow message btw users if there isn't a deal btw them");
                }
                if (sender.Role == AppStatics.AdminRole && (reciever.Role == AppStatics.DeliveryManRole || reciever.Role == AppStatics.ClientRole))
                {
                    var messag = new Message(message.Content, sender.Id, reciever.Id, sender.Id.ToString());
                    await messageRepository.Add(messag);
                    await unitOfWork.SaveChanges();

                    return BaseResponse<AddMessageResponseModel>.Sucess(new AddMessageResponseModel(messag.Id));
                }
                if (reciever.Role == AppStatics.AdminRole && (sender.Role == AppStatics.DeliveryManRole || sender.Role == AppStatics.ClientRole))
                {
                    var messag = new Message(message.Content, sender.Id, reciever.Id, sender.Id.ToString());
                    await messageRepository.Add(messag);
                    await unitOfWork.SaveChanges();
                    await hubContext.Clients.User(messag.RecieverUserId.ToString()).SendAsync("ReceiveMessage", messag);

                    return BaseResponse<AddMessageResponseModel>.Sucess(new AddMessageResponseModel(messag.Id));

                }
                return BaseResponse<AddMessageResponseModel>.Fail();
            }
            catch (Exception ex)
            {
                return BaseResponse<AddMessageResponseModel>.Fail(ex.Message);
            }

        }
        public async Task<BaseResponse<List<string>>> GetClientMessageLink(Guid clientId)
        {
            List<string> WorkIds = [];
            var client =  await clientRepository.Get(clientId);
            if (client == null)
            {
                return BaseResponse<List<string>>.Fail("User not found");
            }
            var messages = await messageRepository.GetAll();
            var clientMessaage = messages.Where(x => x.SenderUserId == client.UserId || x.RecieverUserId == client.UserId);
            foreach (var item in clientMessaage)
            {
                if(item.Sender == null || item.Reciever == null)
                {
                    return BaseResponse<List<string>>.Fail("User not found");
                }
                if (item.Sender!.Role == AppStatics.DeliveryManRole)
                {
                    var man = await deliveryManRepository.GetByUserId(item.SenderUserId);
                    if(man == null)
                    {
                        return BaseResponse<List<string>>.Fail("User not found");
                    }
                    if(!WorkIds.Contains(man.WorkId))
                    {
                        WorkIds.Add(man.WorkId);
                    }
                }
                if (item.Reciever!.Role == AppStatics.DeliveryManRole)
                {
                    var man = await deliveryManRepository.GetByUserId(item.RecieverUserId);
                    if (man == null)
                    {
                        return BaseResponse<List<string>>.Fail("User not found");
                    }
                    if (!WorkIds.Contains(man.WorkId))
                    {
                        WorkIds.Add(man.WorkId);
                    }
                }
            }
            if (WorkIds.Any())
            {
                return BaseResponse<List<string>>.Sucess(WorkIds);
            }
            return BaseResponse<List<string>>.Fail("No One to chat");
        }

        public async Task<BaseResponse<List<string>>> GetDeliveryMessageLink(Guid deliveryManId)
        {
            List<string> PhoneNumbers = [];
            var deliveryMan = await deliveryManRepository.Get(deliveryManId);
            if (deliveryMan == null)
            {
                return BaseResponse<List<string>>.Fail("User not found");
            }
            var messages = await messageRepository.GetAll();
            var deliveryManMessaage = messages.Where(x => x.SenderUserId == deliveryMan.UserId || x.RecieverUserId == deliveryMan.UserId);
            foreach (var item in deliveryManMessaage)
            {
                if (item.Sender == null || item.Reciever == null)
                {
                    return BaseResponse<List<string>>.Fail("User not found");
                }
                if (item.Sender!.Role == AppStatics.ClientRole)
                {
                    var client = await clientRepository.GetByUserId(item.SenderUserId);
                    if (client == null)
                    {
                        return BaseResponse<List<string>>.Fail("User not found");
                    }
                    if (!PhoneNumbers.Contains(client.PhoneNumber))
                    {
                        PhoneNumbers.Add(client.PhoneNumber);
                    }
                }
                if (item.Reciever!.Role == AppStatics.ClientRole)
                {
                    var client = await clientRepository.GetByUserId(item.RecieverUserId);
                    if (client == null)
                    {
                        return BaseResponse<List<string>>.Fail("User not found");
                    }
                    if (!PhoneNumbers.Contains(client.PhoneNumber))
                    {
                        PhoneNumbers.Add(client.PhoneNumber);
                    }
                }
            }
            if (PhoneNumbers.Any())
            {
                return BaseResponse<List<string>>.Sucess(PhoneNumbers);
            }
            return BaseResponse<List<string>>.Fail("No One to chat");
        }
        public async Task<BaseResponse<List<Message>>> GetBtwTwoUsers(Guid firstPerson,Guid secondPerson)
        {
            var messages = await messageRepository.GetMessages(firstPerson, secondPerson);
            
            if(messages.Count > 0)
            {
                return BaseResponse<List<Message>>.Sucess(messages);
            }
            return BaseResponse<List<Message>>.Fail();

        }

    }
}
