using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Configurations
{
    public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            // Primary Key
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasAnnotation("EmailAddress", "true");
            builder.Property(e => e.Phone).IsRequired().HasAnnotation("Phone", "true");
            builder.Property(e => e.Address).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Bio).IsRequired(false);
            builder.Property(e => e.About).IsRequired(false);
            builder.Property(e => e.ImageUrl).IsRequired(false);


        }
    }
}
