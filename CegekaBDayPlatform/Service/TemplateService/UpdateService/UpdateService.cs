using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.TemplateService.UpdateService
{
    public class UpdateService
    {
        private TemplateRepository _templateRepository;

        public UpdateService(CegekaBDayPlatformContext context)
        {
            _templateRepository = new TemplateRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var template = new Template
            {
                Id = request.Id,
                TemplateTypeId = request.TypeId,
                ManagerId = request.ManagerId,
                Message = request.Message
            };
            var updated = _templateRepository.Update(template);
            var result = new ResponseDto { Id = updated.Id };

            return result;
        }

    }
}
