using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class TodoList : BaseAuditableEntity
    {
        public string? Title { get; set; }
        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }

}
