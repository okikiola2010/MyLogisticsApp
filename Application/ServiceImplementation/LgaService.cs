using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class LgaService(ILgaRepository lgaRepository,IUnitOfWork unitOfWork) : ILgaService
    {
        public async Task<BaseResponse<AddLgaResponseModel>> AddLga(AddLgaRequestModel model)
        {
            var lgaList = await lgaRepository.GetLgasByStateId(model.StateId);
            foreach (var item in lgaList)
            {
               if(item.Name == CapitalizeFirstLetter(model.Name))
               {
                    return BaseResponse<AddLgaResponseModel>.Fail("LGA exists in the state list");
               }    
            }
            Lga lga = new Lga(CapitalizeFirstLetter(model.Name), model.StateId, AppStatics.CurrentLoginUser.Id.ToString());
            await lgaRepository.Add(lga);
            await unitOfWork.SaveChanges();
            return BaseResponse<AddLgaResponseModel>.Sucess(new AddLgaResponseModel(lga.Id), "Sucessfully Created");
        }
        public async Task<BaseResponse<List<Lga>>> GetLgasByStateId(Guid stateId)
        {
            var lgas = await lgaRepository.GetLgasByStateId(stateId);
            lgas = lgas.Where(x => !x.IsDeleted).ToList();
            if(lgas.Count == 0)
            {
                return BaseResponse<List<Lga>>.Fail("No lga found");
            }
            return BaseResponse<List<Lga>>.Sucess(lgas);
        }

        public async Task<BaseResponse<List<Lga>>> GetLgasByStateIdForAdmin(Guid stateId)
        {
            var lgas = await lgaRepository.GetLgasByStateId(stateId);
            if (lgas.Count == 0)
            {
                return BaseResponse<List<Lga>>.Fail("No lga found");
            }
            return BaseResponse<List<Lga>>.Sucess(lgas);
        }
        string CapitalizeFirstLetter(string name)
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
    }
}
