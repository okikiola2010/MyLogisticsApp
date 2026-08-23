using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.ServiceImplementation
{
    public class StateService(IStateRepository stateRepository,IUnitOfWork unitOfWork,IUserRepository userRepository,IHttpContextAccessor httpContextAccessor) : IStateService
    {
        public async Task<BaseResponse<AddStateResponseModel>> AddState(AddStateRequestModel model)
        {
            try
            {
                string? userIdString = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString))
                {
                    return BaseResponse<AddStateResponseModel>.Fail("User not authenticated");
                }
                var userId = Guid.Parse(userIdString);
                var currentLogiUser = await userRepository.Get(userId);
                if (currentLogiUser == null)
                {
                    return BaseResponse<AddStateResponseModel>.Fail("User not found");
                }

                var state = await stateRepository.Get(CapitalizeFirstLetter(model.Name));
                if (state != null)
                {
                    return BaseResponse<AddStateResponseModel>.Fail("State name exists");
                }

                if (currentLogiUser!.Role != AppStatics.AdminRole)
                {
                    return BaseResponse<AddStateResponseModel>.Fail("Only Admin can add state");
                }

                state = new State(CapitalizeFirstLetter(model.Name), userId.ToString());
                await stateRepository.Add(state);
                await unitOfWork.SaveChanges();
                return BaseResponse<AddStateResponseModel>.Sucess(new AddStateResponseModel(state.Id), "Sucessfully Added");
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
        private string CapitalizeFirstLetter(string name)
        {
            name = name.Trim();
            name = name.Replace(" ", "");
            name = name.ToLower();

            string word = $"{name[0].ToString().ToUpper()}";
            for (int i = 1; i < name.Length; i++)
            {
                word += name[i];
            }
            return word;
        }
        public async Task<BaseResponse<State?>> GetState(Guid id)
        {
            var state = await stateRepository.Get(id);
            if(state == null)
            {
                return BaseResponse<State?>.Fail("State not found");
            }
            return BaseResponse<State?>.Sucess(state);
        }

        public async Task<BaseResponse<State?>> GetState(string name)
        {
            var state =  await stateRepository.Get(name);
            if(state == null)
            {
                return BaseResponse<State?>.Fail("State not found");
            }
            return BaseResponse<State?>.Sucess(state);
        }

        public async Task<BaseResponse<List<State>>> GetAll()
        {
            var list = await stateRepository.GetAll();
            var newlist = new List<State>();
            foreach (var item in list)
            {
                if (!item.IsDeleted)
                {
                    newlist.Add(item);
                }
            }
            if (newlist.Count == 0)
            {
                return BaseResponse<List<State>>.Fail("No state found");
            }
            return BaseResponse<List<State>>.Sucess(newlist);
        }

        public async Task<BaseResponse<List<State>>> GetAllForAdmin()
        {
            var newlist =  await stateRepository.GetAll();
            if (newlist.Count == 0)
            {
                return BaseResponse<List<State>>.Fail("No state found");
            }
            return BaseResponse<List<State>>.Sucess(newlist);
        }
    }
}
