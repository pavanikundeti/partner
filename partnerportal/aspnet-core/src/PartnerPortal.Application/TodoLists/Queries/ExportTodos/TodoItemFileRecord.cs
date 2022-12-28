using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string? Title { get; set; }

        public bool Done { get; set; }
    }
}
