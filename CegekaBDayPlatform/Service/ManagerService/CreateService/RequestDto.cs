﻿using System;

namespace CegekaBDayPlatform.Service.ManagerService.CreateService
{
    public class RequestDto
    {
        public Guid PersonId { get; set; }

        public static bool IsValid(RequestDto dto)
        {
            if( dto == null)
            {
                return false;
            }

            return true;
        }
    }

    
}
