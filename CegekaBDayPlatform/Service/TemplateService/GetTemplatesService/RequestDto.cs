﻿using System;

namespace CegekaBDayPlatform.Service.TemplateService.GetTemplatesService
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
