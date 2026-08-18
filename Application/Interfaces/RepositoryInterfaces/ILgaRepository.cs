using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
    public interface ILgaRepository
    {
        public Task Add(Lga lga);
        public Task Update(Lga lga);
        public Task<Lga?> Get(Guid id);
        public Task<Lga?> Get(string name);
        public Task<List<Lga>> GetLgasByStateId(Guid stateId);
    }
}
