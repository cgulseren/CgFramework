using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mapping
{
    public class UserOperationClaimMap : IEntityTypeCgConfiguration<UserOperationClaim>
    {
        public void Map(EntityTypeBuilder<UserOperationClaim> entity)
        {
            entity.ToTable("UserOperationClaim");
        }
    }
}
