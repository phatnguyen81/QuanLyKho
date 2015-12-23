using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace QuanLyKho.Core.Domain.Security
{
    public class UserRole : BaseEntity
    {
        public string SystemName { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public ICollection<User> Users { get; set; } 
    }
}
