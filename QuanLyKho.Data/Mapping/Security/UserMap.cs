using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Domain.Security;

namespace QuanLyKho.Data.Mapping.Security
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(u => u.Id);
            this.Property(u => u.Username).HasMaxLength(1000);

            this.HasRequired(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.UserRoleId);

        }
    }
}
