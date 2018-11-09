using System;
using System.Collections.Generic;
using System.Linq;
using CegekaBDayPlatform.Model;

namespace CegekaBDayPlatform.Repository
{
    public class TemplateRepository
    {
        private CegekaBDayPlatformContext _context;

        public TemplateRepository(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        public Template Create(Template template)
        {
            template.Id = Guid.NewGuid();
            _context.Templates.Add(template);
            var success = _context.SaveChanges();
            if (success != 1) template = null;
            return template;
        }

        public Template Get(Guid id)
        {
            return _context.Templates.FirstOrDefault(s => s.Id == id);
        }

        public List<Template> GetAll()
        {
            return _context.Templates.ToList();
        }

        public Template Update(Template template)
        {
            _context.Templates.Attach(template);
            _context.Entry(template).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = _context.SaveChanges();
            return result == 1 ? _context.Templates.FirstOrDefault(s => s.Id == template.Id) : null;
        }

        public Template Delete(Guid id)
        {
            Template template = _context.Templates.FirstOrDefault(s => s.Id == id);
            if (template != null)
            {
                _context.Templates.Attach(template);
                _context.Entry(template).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
            return _context.Templates.FirstOrDefault(s => s.Id == id);
        }
    }
}
