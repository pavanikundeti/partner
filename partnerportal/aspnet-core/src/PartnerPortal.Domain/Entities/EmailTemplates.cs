using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class EmailTemplates
    {

        [Key]
        public Guid EmailTemplateID { get; set; }
        public string? TemplateName { get; set; }

        public string? TemplateCode { get; set; }




        public string? MessageTemplate { get; set; }
    }
}
