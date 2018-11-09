using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.ManagerService.DeleteService
{
    public class DeleteService
    {
        private ManagerRepository _managerRepository;

        public DeleteService(CegekaBDayPlatformContext context)
        {
            _managerRepository = new ManagerRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var manager = _managerRepository.Delete(request.Id);
            var result = new ResponseDto { Id = manager?.Id };
            return result;
        }

    }
}
