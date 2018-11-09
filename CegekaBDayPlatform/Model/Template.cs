using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CegekaBDayPlatform.Model
{
    public class Template
    {
        public Guid? Id { get; set; }
        public Manager Manager { get; set; }
        public Guid? ManagerId { get; set; }
        public TemplateType Type { get; set; }
        [Required]
        public Guid TemplateTypeId { get; set; }
        public string Message { get; set; }
    }
}
