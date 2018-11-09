using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplatesService
{
    public class ResponseDto
    {
        public ICollection<TemplateResponse> Templates { get; set; }

    }

    public class TemplateResponse
    {
        public Guid? Id { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? TypeId { get; set; }
        public string Message { get; set; }
    }
}
