using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Service.ManagerService.GetManagersService
{
    public class ResponseDto
    {
        public ICollection<ManagerResponse> Managers { get; set; }

    }

    public class ManagerResponse
    {
        public Guid? Id { get; set; }
        public Guid? PersonId { get; set; }
    }
}
