using System;
using CreatePersonServiceDto = CegekaBDayPlatform.Service.PersonService.CreatePersonService;
using DeletePersonServiceDto = CegekaBDayPlatform.Service.PersonService.DeletePersonService;
using GetPersonsServiceDto = CegekaBDayPlatform.Service.PersonService.GetPersonsService;
using GetUpcommingBirthDaysServiceDto = CegekaBDayPlatform.Service.PersonService.GetUpcommingBirthDaysService;
using UpdatePersonServiceDto = CegekaBDayPlatform.Service.PersonService.UpdatePersonService;
using Microsoft.AspNetCore.Mvc;
using CegekaBDayPlatform.Service.PersonService.CreatePersonService;
using CegekaBDayPlatform.Service.PersonService.DeletePersonService;
using CegekaBDayPlatform.Service.PersonService.GetPersonsService;
using CegekaBDayPlatform.Service.PersonService.GetUpcommingBirthDaysService;
using CegekaBDayPlatform.Service.PersonService.UpdatePersonService;

namespace CegekaBDayPlatform.Controllers
{
    [Route("api/persons")]
    public class PersonController : Controller
    {
        private CegekaBDayPlatformContext _context;

        public PersonController(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        // GET api/persons
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var service = new GetPersonsService(_context);
            var request = new GetPersonsServiceDto.RequestDto();
            return new ObjectResult(service.Process(request));
        }

        // GET api/persons/Upcomming
        [HttpGet("Upcomming")]
        public IActionResult Upcomming()
        {
            var request = new GetUpcommingBirthDaysServiceDto.RequestDto { NumberOfPersons = 2 };
            var service = new GetUpcommingBirthDaysService(_context);
            return new ObjectResult(service.Process(request));
        }

        // POST api/persons/Upcomming
        [HttpPost("Upcomming")]
        public IActionResult Upcomming([FromBody]GetUpcommingBirthDaysServiceDto.RequestDto value)
        {
            var service = new GetUpcommingBirthDaysService(_context);
            return new ObjectResult(service.Process(value));
        }

        // POST api/persons
        [HttpPost("")]
        public IActionResult Create([FromBody]CreatePersonServiceDto.RequestDto value)
        {
            var service = new CreatePersonService(_context);
            return new ObjectResult(service.Process(value));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UpdatePersonServiceDto.RequestDto value)
        {
            value.Id = id;
            var service = new UpdatePersonService(_context);
            return new ObjectResult(service.Process(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var request = new DeletePersonServiceDto.RequestDto { Id = id };
            var service = new DeletePersonService(_context);
            return new ObjectResult(service.Process(request));
        }

    }
}
