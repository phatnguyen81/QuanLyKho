using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Domain.Security;

namespace QuanLyKho.Data.Mapping.Security
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole");
            this.HasKey(u => u.Id);
            this.Property(r => r.SystemName).HasMaxLength(200);
            this.Property(r => r.Name).HasMaxLength(1000);

            this.HasMany(r => r.Users)
                .WithRequired(u => u.UserRole)
                .HasForeignKey(u => u.UserRoleId);

        }
    }
}
