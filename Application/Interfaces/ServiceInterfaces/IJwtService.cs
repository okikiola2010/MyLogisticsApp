using Domain.Entities;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
    }
}
