﻿using System;

namespace CegekaBDayPlatform.Service.ManagerService.DeleteService
{
    public class RequestDto
    {
        public Guid Id { get; set; }

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
