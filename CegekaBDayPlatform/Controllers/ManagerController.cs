using System;
using CreateServiceDto = CegekaBDayPlatform.Service.ManagerService.CreateService;
using DeleteServiceDto = CegekaBDayPlatform.Service.ManagerService.DeleteService;
using GetManagersServiceDto = CegekaBDayPlatform.Service.ManagerService.GetManagersService;
using Microsoft.AspNetCore.Mvc;
using CegekaBDayPlatform.Service.ManagerService.GetManagersService;
using CegekaBDayPlatform.Service.ManagerService.CreateService;
using CegekaBDayPlatform.Service.ManagerService.DeleteService;

namespace CegekaBDayPlatform.Controllers
{
    [Route("api/managers")]
    public class ManagerController : Controller
    {
        private CegekaBDayPlatformContext _context;

        public ManagerController(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        // GET api/managers
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var service = new GetManagersService(_context);
            var request = new GetManagersServiceDto.RequestDto();
            return new ObjectResult(service.Process(request));
        }

        // POST api/managers
        [HttpPost("")]
        public IActionResult Create([FromBody]CreateServiceDto.RequestDto value)
        {
            var service = new CreateService(_context);
            return new ObjectResult(service.Process(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var request = new DeleteServiceDto.RequestDto { Id = id };
            var service = new DeleteService(_context);
            return new ObjectResult(service.Process(request));
        }

    }
}
