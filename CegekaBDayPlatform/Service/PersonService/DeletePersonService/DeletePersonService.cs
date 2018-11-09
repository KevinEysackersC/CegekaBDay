using CegekaBDayPlatform.Repository;

namespace CegekaBDayPlatform.Service.PersonService.DeletePersonService
{
    public class DeletePersonService
    {
        private PersonRepository _personRepository;

        public DeletePersonService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var person = _personRepository.DeletePerson(request.Id);
            var result = new ResponseDto { Id = person?.Id };
            return result;
        }

    }
}
