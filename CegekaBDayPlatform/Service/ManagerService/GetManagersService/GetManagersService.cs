using CegekaBDayPlatform.Repository;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.ManagerService.GetManagersService
{
    public class GetManagersService
    {
        private ManagerRepository _managerRepository;

        public GetManagersService(CegekaBDayPlatformContext context)
        {
            _managerRepository = new ManagerRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var managers = _managerRepository.GetAll();
            var managerResult = new List<ManagerResponse>();
            foreach (var p in managers)
            {
                var r = new ManagerResponse
                {
                    Id = p.Id,
                    PersonId = p.PersonId,
                    Name = p.Person.Name,
                    FirstName = p.Person.FirstName,
                    PersonCount = p.Persons.Count
                };
                managerResult.Add(r);
            }

            var result = new ResponseDto() { Managers = managerResult };
            return result;
        }

    }
}
