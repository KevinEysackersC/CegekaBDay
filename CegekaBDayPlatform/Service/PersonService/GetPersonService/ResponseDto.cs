using System;

namespace CegekaBDayPlatform.Service.PersonService.GetPersonService
{
    public class ResponseDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
