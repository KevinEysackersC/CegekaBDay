using CegekaBDayPlatform.Repository;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.PersonService.GetUpcommingBirthDaysService
{
    public class GetUpcommingBirthDaysService
    {
        private PersonRepository _personRepository;

        public GetUpcommingBirthDaysService(CegekaBDayPlatformContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public ResponseDto Process(RequestDto request)
        {
            if (!RequestDto.IsValid(request))
            {
                return new ResponseDto() { Persons = new List<PersonResponse>() } ;
            }

            var persons = _personRepository.GetUpcommingBirthDays(request.NumberOfPersons);

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
