﻿
using System;

namespace CegekaBDayPlatform.Service.TemplateService.UpdateService
{
    public class RequestDto
    {
        public Guid? Id { get; set; }
        public string Message { get; set; }
        public Guid TypeId { get; set; }
        public Guid? ManagerId { get; set; }

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
