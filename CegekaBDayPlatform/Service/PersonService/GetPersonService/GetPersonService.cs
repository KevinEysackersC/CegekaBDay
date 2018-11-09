using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.PersonService.GetPersonService
{
    public class GetPersonService
    {
        private PersonRepository _personRepository;

        public GetPersonService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var person = _personRepository.GetPerson(request.Id);
            var result = new ResponseDto
            {
                Id = person.Id,
                DateOfBirth = person.DateOfBirth,
                Name = person.Name,
                FirstName = person.FirstName,
                ManagerId = person.ManagerId
            };
            return result;
        }

    }
}
