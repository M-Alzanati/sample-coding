using Example.CodingTask.Core.Entity;
using Example.CodingTask.Data.Configuration.EntityConfiguration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.CodingTask.Data.Configuration.EntityConfiguration
{
    public class UserMatchConfiguration : BaseEntityConfiguration<UserMatch>
    {
        public override void Configure(EntityTypeBuilder<UserMatch> builder)
        {
            builder
                .HasKey(e => new { e.UserId, e.MatchId });

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UserMatches)
                .HasForeignKey(e => e.UserId);

            builder
                .HasOne(e => e.Match)
                .WithMany(e => e.UserMatches)
                .HasForeignKey(e => e.MatchId);
        }
    }
}
