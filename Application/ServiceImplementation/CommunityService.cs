using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.Service;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.ServiceImplementation
{
    public class CommunityService(ICommunityRepository communityRepository,IUnitOfWork unitOfWork,IUserRepository userRepository,IHttpContextAccessor httpContextAccessor) : ICommunityService
    {
        public async Task<BaseResponse<AddCommunityResponseModel>> AddCountry(AddCommunityRequestModel model)
        {
            //await service.AddDeliveryMan(new AddDeliverManRequestModel("","","","",""));
            try
            {
                var coun = await communityRepository.Get(CapitalizeFirstLetter(model.Name));
                if (coun != null)
                {
                    return BaseResponse<AddCommunityResponseModel>.Fail("Country exists....");
                }
                var userIdString = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString))
                {
                    return BaseResponse<AddCommunityResponseModel>.Fail("User not authenticated");

                }
                Guid userId = Guid.Parse(userIdString);
                User? currentLoginUser = await userRepository.Get(userId);
                if (currentLoginUser == null)
                {
                    return BaseResponse<AddCommunityResponseModel>.Fail("User not found");
                }
                if (currentLoginUser.Role != AppStatics.AdminRole)
                {
                    return BaseResponse<AddCommunityResponseModel>.Fail("Only admin can add community");
                }
                var c = new Community(CapitalizeFirstLetter(model.Name), model.LgaId, userId.ToString());
                await communityRepository.Add(c);
                await unitOfWork.SaveChanges();
                return BaseResponse<AddCommunityResponseModel>.Sucess(new AddCommunityResponseModel(c.Id));
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
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
            if(lga != null)
            {
                return BaseResponse<Community?>.Sucess(lga);
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
