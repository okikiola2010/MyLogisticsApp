using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class State:BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Lga> Lgas { get; set; } = [];
        private State(){}
        public State(string name,string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
            
        }
        public void Update(string name,string updatedBy,bool isDeleted)
        {
            Name = name;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
