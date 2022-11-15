using Example.CodingTask.Core.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.CodingTask.Data.Configuration.EntityConfiguration.Base
{
    public class GuidEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
        where TEntity : GuidEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

