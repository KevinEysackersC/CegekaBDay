using Newtonsoft.Json;
using System;

namespace CegekaBDayPlatform.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
