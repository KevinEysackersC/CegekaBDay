using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CegekaBDayPlatform.Model
{
    public class Manager
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid PersonId { get; set; }
        [NotMapped]
        public Person Person { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
