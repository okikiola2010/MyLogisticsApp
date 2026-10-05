using Domain.Entities;

namespace Application.Dtos
{
    public class LgaDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public Guid StateId { get; set; }
        public State? State { get; set; }
        public List<Community> Lgas { get; set; } = [];
        public string Name { get; set; } = default!;

    }
    public class AddLgaRequestModel
    {
        public string Name { get; set; } = default!;
        public Guid StateId { get; set; }
    }

    public record AddLgaResponseModel(Guid Id);
}
