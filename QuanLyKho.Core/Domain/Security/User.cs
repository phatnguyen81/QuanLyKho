using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace QuanLyKho.Core.Domain.Security
{
    public class User : BaseEntity
    {
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public UserRole UserRole { get; set; }
    }


}
