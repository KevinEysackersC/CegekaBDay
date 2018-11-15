using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CegekaBDayPlatform.Model
{
    public class Person
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }
    }
}
