using System;
using System.Collections.Generic;

namespace CegekaBDayPlatform.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
