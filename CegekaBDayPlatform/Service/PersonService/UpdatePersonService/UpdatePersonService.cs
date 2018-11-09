using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.PersonService.UpdatePersonService
{
    public class UpdatePersonService
    {
        private PersonRepository _personRepository;

        public UpdatePersonService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var person = new Person
            {
                Id = request.Id,
                Name = request.Name,
                FirstName = request.FirstName,
                DateOfBirth = request.DateOfBirth,
                ManagerId = request.ManagerId
            };
            var updatedPerson = _personRepository.UpdatePerson(person);
            var result = new ResponseDto { Id = updatedPerson.Id };

            return result;
        }

    }
}
