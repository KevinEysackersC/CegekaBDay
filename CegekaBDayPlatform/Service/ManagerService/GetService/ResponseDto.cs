using System;

namespace CegekaBDayPlatform.Service.ManagerService.GetService
{
    public class ResponseDto
    {
        public Guid? Id { get; set; }
        public Guid? PersonId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int PersonCount { get; set; }
    }

}
