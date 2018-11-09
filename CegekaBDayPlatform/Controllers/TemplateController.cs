using System;
using CreateServiceDto = CegekaBDayPlatform.Service.TemplateService.CreateService;
using DeleteServiceDto = CegekaBDayPlatform.Service.TemplateService.DeleteService;
using UpdateServiceDto = CegekaBDayPlatform.Service.TemplateService.UpdateService;
using GetTemplatesServiceDto = CegekaBDayPlatform.Service.TemplateService.GetTemplatesService;
using Microsoft.AspNetCore.Mvc;
using CegekaBDayPlatform.Service.TemplateService.CreateService;
using CegekaBDayPlatform.Service.TemplateService.DeleteService;
using CegekaBDayPlatform.Service.TemplateService.GetTemplatesService;
using CegekaBDayPlatform.Service.TemplateService.UpdateService;

namespace CegekaBDayPlatform.Controllers
{
    [Route("api/templates")]
    public class TemplateController : Controller
    {
        private CegekaBDayPlatformContext _context;

        public TemplateController(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        // GET api/templates
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var service = new GetTemplatesService(_context);
            var request = new GetTemplatesServiceDto.RequestDto();
            return new ObjectResult(service.Process(request));
        }

        // POST api/templates
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

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UpdateServiceDto.RequestDto value)
        {
            value.Id = id;
            var service = new UpdateService(_context);
            return new ObjectResult(service.Process(value));
        }
    }
}
