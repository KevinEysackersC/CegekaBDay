using System;
using System.Collections.Generic;
using System.Linq;
using CegekaBDayPlatform.Model;

namespace CegekaBDayPlatform.Repository
{
    public class PersonRepository
    {
        private CegekaBDayPlatformContext _context;

        public PersonRepository(CegekaBDayPlatformContext context)
        {
            _context = context;
        }


        public Person CreatePerson(Person person)
        {
            person.Id = Guid.NewGuid();
            _context.Persons.Add(person);
            var success = _context.SaveChanges();
            if (success != 1) person = null;
            return person;
        }

        public Person GetPerson(Guid id)
        {
            return _context.Persons.FirstOrDefault(s => s.Id == id);
        }

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public List<Person> GetUpcommingBirthDays(int count)
        {
            var persons = new List<Person>();
            var temp1 = _context.Persons.Where(p =>
                p.DateOfBirth.Month * 100 + p.DateOfBirth.Day >=
                DateTime.Today.Month * 100 + DateTime.Today.Day)
                .OrderBy(p => p.DateOfBirth.Month * 100 + p.DateOfBirth.Day)
                .Take(count)
                .ToList();

            persons.AddRange(temp1);

            if (persons.Count < count)
            {
                var temp2 = _context.Persons.Where(p =>
                    p.DateOfBirth.Month * 100 + p.DateOfBirth.Day <
                    DateTime.Today.Month * 100 + DateTime.Today.Day)
                    .OrderBy(p => p.DateOfBirth.Month * 100 + p.DateOfBirth.Day)
                    .Take(count - persons.Count)
                    .ToList();

                persons.AddRange(temp2);
            }

            return persons;

        }

        public Person UpdatePerson(Person person)
        {
            _context.Persons.Attach(person);
            _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = _context.SaveChanges();
            return result == 1 ? _context.Persons.FirstOrDefault(s => s.Id == person.Id) : null;

        }

        public Person DeletePerson(Guid id)
        {
            Person person = _context.Persons.FirstOrDefault(s => s.Id == id);
            if (person != null)
            {
                _context.Persons.Attach(person);
                _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
            return _context.Persons.FirstOrDefault(s => s.Id == id);
        }
    }
}
