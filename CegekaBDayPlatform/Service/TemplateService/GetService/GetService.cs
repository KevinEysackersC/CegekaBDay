using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.TemplateService.GetService
{
    public class GetService
    {
        private ManagerRepository _managerRepository;

        public GetService(CegekaBDayPlatformContext context)
        {
            _managerRepository = new ManagerRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var manager = _managerRepository.Get(request.Id);
            var result = new ResponseDto
            {
                Id = manager.Id,
                PersonId = manager.PersonId
            };
            return result;
        }

    }
}
