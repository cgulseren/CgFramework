using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class UserMap : IEntityTypeCgConfiguration<User>
    {
        public void Map(EntityTypeBuilder<User> entity)
        {

            entity.ToTable("Users");
            entity.Property(x => x.Email).HasColumnType("varchar(60)").IsRequired();
            entity.Property(x => x.FirstName).HasColumnType("nvarchar(60)").IsRequired();
            entity.Property(x => x.LastName).HasColumnType("nvarchar(60)").IsRequired();
            entity.HasIndex(e => e.Email);
        }
    }
}
