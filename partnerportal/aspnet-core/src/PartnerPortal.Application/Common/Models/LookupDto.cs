using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Application.Common.Models
{
    public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public string? Title { get; set; }
    }
}
