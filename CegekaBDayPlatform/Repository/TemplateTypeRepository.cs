using System;
using System.Collections.Generic;
using System.Linq;
using CegekaBDayPlatform.Model;

namespace CegekaBDayPlatform.Repository
{
    public class TemplateTypeRepository
    {
        private CegekaBDayPlatformContext _context;

        public TemplateTypeRepository(CegekaBDayPlatformContext context)
        {
            _context = context;
        }

        public List<TemplateType> GetAll()
        {
            return _context.TemplateTypes.ToList();
        }

    }
}
