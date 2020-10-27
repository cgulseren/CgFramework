using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mapping
{
    public interface IEntityTypeCgConfiguration<TEntityType> where TEntityType : class
    {
        void Map(EntityTypeBuilder<TEntityType> entity);
    }
}
