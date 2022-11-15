using Example.CodingTask.Core.Entity;
using Example.CodingTask.Data.Configuration.EntityConfiguration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.CodingTask.Data.Configuration.EntityConfiguration
{
    public class UserConfiguration : GuidEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(e => e.UserMatches)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}

