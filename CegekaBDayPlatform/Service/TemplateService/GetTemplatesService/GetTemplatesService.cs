using CegekaBDayPlatform.Repository;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplatesService
{
    public class GetTemplatesService
    {
        private TemplateRepository _templateRepository;

        public GetTemplatesService(CegekaBDayPlatformContext context)
        {
            _templateRepository = new TemplateRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var templates = _templateRepository.GetAll();
            var templatesResult = new List<TemplateResponse>();
            foreach (var t in templates)
            {
                var r = new TemplateResponse
                {
                    Id = t.Id,
                    ManagerId = t.ManagerId,
                    TypeId = t.TemplateTypeId,
                    Message = t.Message
                };
                templatesResult.Add(r);
            }

            var result = new ResponseDto() { Templates = templatesResult };
            return result;
        }

    }
}
