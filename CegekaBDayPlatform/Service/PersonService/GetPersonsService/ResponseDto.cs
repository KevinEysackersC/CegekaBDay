using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.PersonService.GetPersonsService
{
    public class ResponseDto
    {
        public ICollection<PersonResponse> Persons { get; set; }

        public static bool IsValid(RequestDto dto)
        {
            if (dto == null)
            {
                return false;
            }

            return true;
        }
    }

    public class PersonResponse
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
