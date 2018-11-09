using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.PersonService.CreatePersonService
{
    public class CreatePersonService
    {
        private PersonRepository _personRepository;

        public CreatePersonService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            if (!RequestDto.IsValid(request))
            {
                return null;
            }


            var person = new Person
            {
                Name = request.Name,
                FirstName = request.FirstName,
                DateOfBirth = request.DateOfBirth,
                ManagerId = request.ManagerId
            };
            var createdPerson = _personRepository.CreatePerson(person);
            var result = new ResponseDto { Id = createdPerson.Id };
            return result;
        }

    }
}
