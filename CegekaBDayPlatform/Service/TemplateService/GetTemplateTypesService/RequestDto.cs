using System;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplateTypesService
{
    public class RequestDto
    {

        public static bool IsValid(RequestDto dto)
        {
            if (dto == null)
            {
                return false;
            }

            return true;
        }
    }
}
