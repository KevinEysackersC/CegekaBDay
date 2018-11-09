using System;

namespace CegekaBDayPlatform.Service.PersonService.CreatePersonService
{
    public class RequestDto
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid? ManagerId { get; set; }

        public static bool IsValid(RequestDto dto)
        {
            if( dto == null)
            {
                return false;
            }

            return true;
        }
    }

    
}
