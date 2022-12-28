using CsvHelper.Configuration;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using System.Globalization;

namespace PartnerPortal.Infrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
