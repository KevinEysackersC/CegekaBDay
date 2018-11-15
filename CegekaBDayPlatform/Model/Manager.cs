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
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        [InverseProperty("Manager")]
        public ICollection<Person> Persons { get; set; }
    }
}
