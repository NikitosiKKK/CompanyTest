using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
