using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
    }
}
