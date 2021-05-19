using KhoaLuan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Configurations
{
    internal class NotificationCF : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("NotificationCFs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Path).IsRequired().HasMaxLength(20);
            builder.Property(x => x.View).HasDefaultValue(false);
            builder.Property(x => x.Time).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Receiver).WithMany(x => x.NotificationReceiver).HasForeignKey(x => x.IdReceiver);
        }
    }
}