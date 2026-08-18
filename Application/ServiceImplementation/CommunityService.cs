using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.Service;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class CommunityService(ICommunityRepository communityRepository,IUnitOfWork unitOfWork, IDeliveryManService service) : ICommunityService
    {
        public async Task<BaseResponse<AddCommunityResponseModel>> AddCountry(AddCommunityRequestModel model)
        {
            //await service.AddDeliveryMan(new AddDeliverManRequestModel("","","","",""));
            var coun = await communityRepository.Get(CapitalizeFirstLetter(model.Name));
            if (coun != null) 
            {
                return  BaseResponse<AddCommunityResponseModel>.Fail("Country exists....");
            }
            var c = new Community(CapitalizeFirstLetter(model.Name),model.LgaId,AppStatics.CurrentLoginUser.Id.ToString());
            await communityRepository.Add(c);
            await unitOfWork.SaveChanges();
            return BaseResponse<AddCommunityResponseModel>.Sucess(new AddCommunityResponseModel(c.Id));
        }

        public async Task<BaseResponse<List<Community>>> GetAll(Guid lgaId)
        {
            var lgas = await communityRepository.GetCommunitiesByLgaId(lgaId);
            lgas = lgas.Where(c => !c.IsDeleted).ToList();
            if (lgas.Count == 0)
            {
                return BaseResponse<List<Community>>.Fail();
            }
            return BaseResponse<List<Community>>.Sucess(lgas);
        }
        public async Task<BaseResponse<List<Community>>> GetAllForAdmin(Guid lgaId)
        {
            var lgas = await communityRepository.GetCommunitiesByLgaId(lgaId);
            if(lgas.Count == 0)
            {
                return BaseResponse<List<Community>>.Fail();
            }
            return BaseResponse<List<Community>>.Sucess(lgas);
        }
        public async Task<BaseResponse<Community?>> Get(Guid id)
        {
            var lga = await communityRepository.Get(id);
            if(lga == null)
            {
                return BaseResponse<Community?>.Fail("Lga doesn't exists");
            }
            return BaseResponse<Community?>.Fail("Lga doesn't exists");
        }
        public async Task<BaseResponse<Community?>> Get(string name)
        {
            var lga = await communityRepository.Get(name);
            if (lga == null)
            {
                return BaseResponse<Community?>.Fail("Lga doesn't exists");
            }
            return BaseResponse<Community?>.Fail("Lga doesn't exists");
        }

        private string CapitalizeFirstLetter(string name)
        {
            name = name.Trim();
            name = name.Replace(" ", "");
            string word = $"{name[0].ToString().ToUpper()}";
            for (int i = 1; i < name.Length; i++)
            {
                word += name[i];
            }
            return word;
        }
    }
}
