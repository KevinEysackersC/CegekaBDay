using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplateTypesService
{
    public class ResponseDto
    {
        public ICollection<TemplateTypeResponse> TemplateTypes { get; set; }

    }

    public class TemplateTypeResponse
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
    }

}
