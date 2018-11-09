using Newtonsoft.Json;
using System;

namespace CegekaBDayPlatform.Model
{
    public class Template
    {
        public Guid? Id { get; set; }
        public Manager Manager { get; set; }
        public TemplateType Type { get; set; }
        public string Message { get; set; }
    }
}
