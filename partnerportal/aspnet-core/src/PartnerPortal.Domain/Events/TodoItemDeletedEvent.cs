using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Events
{
    public class TodoItemDeletedEvent : BaseEvent
    {
        public TodoItemDeletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
