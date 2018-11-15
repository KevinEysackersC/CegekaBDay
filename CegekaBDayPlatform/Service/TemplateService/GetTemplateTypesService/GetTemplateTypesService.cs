using CegekaBDayPlatform.Repository;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplateTypesService
{
    public class GetTemplateTypesService
    {
        private TemplateTypeRepository _templateTypeRepository;

        public GetTemplateTypesService(CegekaBDayPlatformContext context)
        {
            _templateTypeRepository = new TemplateTypeRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var templates = _templateTypeRepository.GetAll();
            var templateTypesResult = new List<TemplateTypeResponse>();
            foreach (var t in templates)
            {
                var r = new TemplateTypeResponse
                {
                    Id = t.Id,
                    Description = t.Description
                };
                templateTypesResult.Add(r);
            }

            var result = new ResponseDto() { TemplateTypes = templateTypesResult };
            return result;
        }

    }
}
