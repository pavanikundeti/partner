using CsvHelper;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using PartnerPortal.Infrastructure.Files.Maps;
using System.Globalization;

namespace PartnerPortal.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
