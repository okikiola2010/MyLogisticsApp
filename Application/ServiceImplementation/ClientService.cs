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
    public class ClientService(IClientRepository clientRepository,IUserRepository userRepository,IUnitOfWork unitOfWork) : IClientService
    {
        public async Task<BaseResponse<AddClientResponseModel>> AddClient(AddClientRequestModel model)
        {
            var user = await userRepository.Get(model.Email);
            var client = await clientRepository.Get(model.PhoneNumber); 
            if(user != null)
            {
                return BaseResponse<AddClientResponseModel>.Fail("An account with this email exists");
            }
            if (client != null)
            {
                return BaseResponse<AddClientResponseModel>.Fail("An account with this phonenumber exists");
            }
            if(client == null && user == null)
            {

                user = new User(model.Email,BCrypt.Net.BCrypt.HashPassword(model.Password),AppStatics.ClientRole);
                client = new Client(model.FirstName, model.LastName,user.Id,model.PhoneNumber,user.Id.ToString());
                await userRepository.Add(user);
                await clientRepository.Add(client);
                await unitOfWork.SaveChanges();
                return BaseResponse<AddClientResponseModel>.Sucess(new AddClientResponseModel(client.Id));
            }
            return BaseResponse<AddClientResponseModel>.Fail();
        }


        public async Task<BaseResponse<ClientDto>> GetClient(Guid id)
        {
            var client = await clientRepository.Get(id);
            if(client == null)
            {
                return BaseResponse<ClientDto>.Fail("Account not found.........");
            }
            return BaseResponse<ClientDto>.Sucess(client.Adapt<ClientDto>(), "Sucessfully found");
        }

        public async Task<BaseResponse<ClientDto>> GetClient(string phonenumber)
        {
            var client = await clientRepository.Get(phonenumber);
            if (client == null)
            {
                return BaseResponse<ClientDto>.Fail($"No account was found with dis phonenumber => {phonenumber}");
            }
            return BaseResponse<ClientDto>.Sucess(client.Adapt<ClientDto>(), "Sucessfully found");
        }
        public async Task<BaseResponse<List<ClientDto>>> GetAll()
        {
            var list = await clientRepository.GetAll();
            list = list.Where(x => !x.IsDeleted).ToList();
            if(list.Count == 0)
            {
                return BaseResponse<List<ClientDto>>.Fail("No Client Found");
            }
            return BaseResponse<List<ClientDto>>.Sucess(list.Adapt<List<ClientDto>>());
        }
    }
}
