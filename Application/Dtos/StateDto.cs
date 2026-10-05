using Domain.Entities;

namespace Application.Dtos
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public string Name { get; set; } = default!;
        public List<Lga> Lgas { get; set; } = [];
    }
    public class AddStateRequestModel
    {
        public string Name { get; set; } = default!;
    }
    public record AddStateResponseModel(Guid Id);
}
