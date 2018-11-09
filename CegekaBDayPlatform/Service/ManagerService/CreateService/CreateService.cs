using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.ManagerService.CreateService
{
    public class CreateService
    {
        private ManagerRepository _managerRepository;

        public CreateService(CegekaBDayPlatformContext context)
        {
            _managerRepository = new ManagerRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            if (!RequestDto.IsValid(request))
            {
                return null;
            }

            var manager = new Manager
            {
               PersonId = request.PersonId
            };
            var created = _managerRepository.Create(manager);
            var result = new ResponseDto { Id = created.Id };
            return result;
        }

    }
}
