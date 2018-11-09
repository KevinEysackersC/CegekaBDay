using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.TemplateService.CreateService
{
    public class CreateService
    {
        private TemplateRepository _templateRepository;

        public CreateService(CegekaBDayPlatformContext context)
        {
            _templateRepository = new TemplateRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            if (!RequestDto.IsValid(request))
            {
                return null;
            }

            var template = new Template
            {
                ManagerId = request.ManagerId,
                TemplateTypeId = request.TypeId,
                Message = request.Message
            };
            var created = _templateRepository.Create(template);
            var result = new ResponseDto { Id = created.Id };
            return result;
        }

    }
}
