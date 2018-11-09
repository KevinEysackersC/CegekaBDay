using CegekaBDayPlatform.Repository;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.PersonService.GetPersonsService
{
    public class GetPersonsService
    {
        private PersonRepository _personRepository;

        public GetPersonsService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            var persons = _personRepository.GetAllPersons();

            var personResult = new List<PersonResponse>();
            foreach (var p in persons)
            {
                var r = new PersonResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    FirstName = p.FirstName,
                    DateOfBirth = p.DateOfBirth,
                    ManagerId = p.ManagerId
                };
                personResult.Add(r);
            }

            var result = new ResponseDto() { Persons = personResult };

            return result;
        }

    }
}
