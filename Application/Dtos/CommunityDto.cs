using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class CommunityDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public Guid LgaId { get; set; }
        public Lga? Lga { get; set; }
        public string Name { get; set; } = default!;

    }
    public record AddCommunityRequestModel(string Name, Guid LgaId);
    public record AddCommunityResponseModel(Guid Id);

}
