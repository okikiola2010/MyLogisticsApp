using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class DeliveryManService(IDeliveryManRepository deliveryManRepository,IUnitOfWork unitOfWork,IUserRepository userRepository) : IDeliveryManService
    {
        public async Task<BaseResponse<AddDeliverManResponseModel>> AddDeliveryMan(AddDeliverManRequestModel model)
        {
            var user = await userRepository.Get(model.Email);
            if (user != null)
            {
                return BaseResponse<AddDeliverManResponseModel>.Fail("An account with this email exists");
            }
           
            if (user == null)
            {

                user = new User(model.Email, BCrypt.Net.BCrypt.HashPassword(model.Password), AppStatics.ClientRole);
                DeliveryMan deliveryMan = new DeliveryMan(model.FirstName, model.LastName, user.Id, user.Id.ToString());
                var deliveryMen = await deliveryManRepository.GetAll();

                while(deliveryMen.Any(x => x.WorkId == deliveryMan.WorkId))
                {
                    deliveryMan.Update(deliveryMan.FirstName, deliveryMan.LastName, GetWorkId(deliveryMan.FirstName, deliveryMan.LastName), user.Id, user.Id.ToString(), deliveryMan.IsDeleted, deliveryMan.LastTimeOrdered);
                }
                await userRepository.Add(user);
                await deliveryManRepository.Add(deliveryMan);
                await unitOfWork.SaveChanges();
                return BaseResponse<AddDeliverManResponseModel>.Sucess(new AddDeliverManResponseModel(deliveryMan.Id));
            }
            return BaseResponse<AddDeliverManResponseModel>.Fail();
        }

        public async Task<BaseResponse<DeliverManDto>> Get(Guid id)
        {
            var man = await deliveryManRepository.Get(id);
            if(man == null)
            {
                return BaseResponse<DeliverManDto>.Fail("Delivery man not found");
            }
            return BaseResponse<DeliverManDto>.Sucess(man.Adapt<DeliverManDto>());
        }

        public async Task<BaseResponse<DeliverManDto>> Get(string workId)
        {
            var man = await deliveryManRepository.Get(workId);
            if (man == null)
            {
                return BaseResponse<DeliverManDto>.Fail("Delivery man not found");
            }
            return BaseResponse<DeliverManDto>.Sucess(man.Adapt<DeliverManDto>());
        }

        

        public string GetWorkId(string firstName, string lastName)
        {
            Random random = new Random();
            int b = random.Next(111111, 999999);
            string r = $"{b}-{Guid.NewGuid().ToString().Split("-")[0].ToString().ToUpper()}@{firstName[0].ToString().ToUpper()}{lastName[0].ToString().ToUpper()}".ToUpper();
            return r;
        }
        public async Task<BaseResponse<List<DeliverManDto>>> GetAll()
        {
            var list = await deliveryManRepository.GetAll();
            list = list.Where(x => !x.IsDeleted).ToList();
            if (list.Count == 0)
            {
                return BaseResponse<List<DeliverManDto>>.Fail("No DeliveryMan Found");
            }
            return BaseResponse<List<DeliverManDto>>.Sucess(list.Adapt<List<DeliverManDto>>());
        }
    }
}
