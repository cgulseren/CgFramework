using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=CgFramework; Integrated Security=false; User ID=sa;Pwd=cb020611; MultipleActiveResultSets=True;",
                serverDbContextOptionsBuilder =>
                {
                    var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                    serverDbContextOptionsBuilder.CommandTimeout(minutes);
                    serverDbContextOptionsBuilder.EnableRetryOnFailure();
                });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Interface that all of our Entity maps implement
            var mappingInterface = typeof(DataAccess.Concrete.Mapping.IEntityTypeCgConfiguration<>);

            // Types that do entity mapping
            var mappingTypes = typeof(DataAccess.Concrete.Mapping.IEntityTypeCgConfiguration<>).GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));

            // Get the generic Entity method of the ModelBuilder type
            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                        x.IsGenericMethod &&
                        x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                // Get the type of entity to be mapped
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();

                // Get the method builder.Entity<TEntity>
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);

                // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                var entityBuilder = genericEntityMethod.Invoke(builder, null);

                // Create the mapping type and do the mapping
                var mapper = Activator.CreateInstance(mappingType);

                mapper.GetType().GetMethod("Map").Invoke(mapper, new[] { entityBuilder });
            }
        }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
