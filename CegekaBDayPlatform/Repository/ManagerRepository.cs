using System;
using System.Collections.Generic;
using System.Linq;
using CegekaBDayPlatform.Model;

namespace CegekaBDayPlatform.Repository
{
    public class ManagerRepository
    {
        private CegekaBDayPlatformContext _context;

        public ManagerRepository(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        public Manager Create(Manager manager)
        {
            manager.Id = Guid.NewGuid();
            _context.Managers.Add(manager);
            var success = _context.SaveChanges();
            if (success != 1) manager = null;
            return manager;
        }

        public Manager Get(Guid id)
        {
            return _context.Managers.FirstOrDefault(s => s.Id == id);
        }

        public List<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public Manager Delete(Guid id)
        {
            Manager manager = _context.Managers.FirstOrDefault(s => s.Id == id);
            if (manager != null)
            {
                _context.Managers.Attach(manager);
                _context.Entry(manager).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
            return _context.Managers.FirstOrDefault(s => s.Id == id);
        }
    }
}
