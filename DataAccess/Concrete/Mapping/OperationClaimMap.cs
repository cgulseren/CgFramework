using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Mapping
{
    public class OperationClaimMap : IEntityTypeCgConfiguration<OperationClaim>
    {
        public void Map(EntityTypeBuilder<OperationClaim> entity)
        {
            entity.ToTable("OperationClaim");
            entity.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
        }
    }
}
