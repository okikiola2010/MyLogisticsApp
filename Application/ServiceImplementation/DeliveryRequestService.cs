using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class DeliveryRequestService(IDeliveryRequestRepository deliveryRequestRepository,IDeliveryRepository deliveryRepository,ICommunityRepository communityRepository,IClientRepository clientRepository,ILocationRepository locationRepository,IUnitOfWork unitOfWork) : IDeliveryRequestService
    {
        public async Task<BaseResponse<AddDeliveryReqResponseModel?>> CreateRequest(AddDeliveryReqRequestModel model)
        {
            if (AppStatics.CurrentLoginUser == null)
            {
                return BaseResponse<AddDeliveryReqResponseModel?>.Fail("User not found");
            }
            var commDev = await communityRepository.Get(model.DeliveryCommunityId);
            var commPick = await communityRepository.Get(model.PickUpCommunityId);
            if (commDev == null || commPick == null)
            {
                return BaseResponse<AddDeliveryReqResponseModel?>.Fail("Location(s) not found");
            }
            var list = await deliveryRepository.GetAll();
            var delivery = list.FirstOrDefault(d => d.IsAvailable && !d.HasDelivered && d.LgaId == commDev.LgaId);
            if(delivery == null)
            {
                Client? cl = await clientRepository.GetByUserId(AppStatics.CurrentLoginUser.Id);
                Location locationDev = new Location(commDev.Lga!.StateId, commDev.LgaId, commDev.Id,AppStatics.CurrentLoginUser.Id.ToString());
                Location locationPick = new Location(commPick.Lga!.StateId, commPick.LgaId, commPick.Id,AppStatics.CurrentLoginUser.Id.ToString());
                delivery = new Delivery(commDev.LgaId);
                DeliveryRequest request = new DeliveryRequest(delivery.Id, locationPick.Id, locationDev.Id, cl!.Id, AppStatics.CurrentLoginUser.Id.ToString(), model.IsUrgent);
                await locationRepository.Add(locationPick);
                await locationRepository.Add(locationDev);
                await deliveryRepository.Add(delivery);
                await deliveryRequestRepository.Add(request);
                await unitOfWork.SaveChanges();
                if (model.IsUrgent)
                {
                    return BaseResponse<AddDeliveryReqResponseModel?>.Sucess(new AddDeliveryReqResponseModel(request.Id),"Ur load will start to move at least in two days time");
                }
                else if(!model.IsUrgent)
                {
                    return BaseResponse<AddDeliveryReqResponseModel?>.Sucess(new AddDeliveryReqResponseModel(request.Id), "Ur load will start to move as soon as possible");
                }
            }
            if (delivery != null)
            {
                Client? cl = await clientRepository.GetByUserId(AppStatics.CurrentLoginUser.Id);
                Location locationDev = new Location(commDev.Lga!.StateId, commDev.LgaId, commDev.Id, AppStatics.CurrentLoginUser.Id.ToString());
                Location locationPick = new Location(commPick.Lga!.StateId, commPick.LgaId, commPick.Id, AppStatics.CurrentLoginUser.Id.ToString());
                DeliveryRequest request = new DeliveryRequest(delivery.Id, locationPick.Id, locationDev.Id, cl!.Id, AppStatics.CurrentLoginUser.Id.ToString(), model.IsUrgent);
                await locationRepository.Add(locationPick);
                await locationRepository.Add(locationDev);
                await deliveryRequestRepository.Add(request);
                await unitOfWork.SaveChanges();
                if (model.IsUrgent)
                {
                    return BaseResponse<AddDeliveryReqResponseModel?>.Sucess(new AddDeliveryReqResponseModel(request.Id), "Your load will start to move at least in two days time");
                }
                else if (!model.IsUrgent)
                {
                    return BaseResponse<AddDeliveryReqResponseModel?>.Sucess(new AddDeliveryReqResponseModel(request.Id), "Your load will start to move as soon as possible");
                }
            }
            return BaseResponse<AddDeliveryReqResponseModel?>.Fail();
        }
    }
}
