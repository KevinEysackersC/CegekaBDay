using System;
using System.Net;
using System.Net.Http;
using System.Text;
using CegekaBDayPlatform.Model;
using CegekaBDayPlatform.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CegekaBDayPlatform.Controllers
{
    [Route("api/persons")]
    public class PersonController : Controller
    {
        private static PersonService _service;

        public PersonController(CegekaBDayPlatformContext context)
        {
            _service = new PersonService(context);
        }

        // GET api/persons
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return new ObjectResult(_service.GetAllPersons());
        }

        // GET api/persons/Upcomming
        [HttpGet("Upcomming")]
        public IActionResult Upcomming()
        {
            return new ObjectResult(_service.GetUpcommingBirthDays(2));
        }

        // POST api/person/Upcomming
        [HttpPost("Upcomming")]
        public IActionResult Upcomming([FromBody]int count)
        {
            return new ObjectResult(_service.GetUpcommingBirthDays(count));
        }

        // POST api/persons
        [HttpPost("")]
        public IActionResult Create([FromBody]Person value)
        {
            return new ObjectResult(_service.CreatePerson(value));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]Person value)
        {
            value.Id = id;
            return new ObjectResult(_service.UpdatePerson(value));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return new ObjectResult(_service.DeletePerson(id));
        }

    }
}
