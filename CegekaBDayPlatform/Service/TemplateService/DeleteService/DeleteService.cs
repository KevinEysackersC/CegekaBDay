using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.TemplateService.DeleteService
{
    public class DeleteService
    {
        private TemplateRepository _templateRepository;

        public DeleteService(CegekaBDayPlatformContext context)
        {
            _templateRepository = new TemplateRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var template = _templateRepository.Delete(request.Id);
            var result = new ResponseDto { Id = template?.Id };
            return result;
        }

    }
}
