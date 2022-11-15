using System;
using System.Collections.Generic;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Data.Configuration.EntityConfiguration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.CodingTask.Data.Configuration.EntityConfiguration
{
    public class MatchConfiguration : GuidEntityConfiguration<Match>
    {
        public override void Configure(EntityTypeBuilder<Match> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(e => e.UserMatches)
                .WithOne(e => e.Match)
                .HasForeignKey(e => e.MatchId);

            builder
                .Property(e => e.TimeStamp)
                .HasColumnType("datetime");

            builder.HasData(new List<Match>
            {
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match A",
                    TimeStamp = DateTime.Now.AddMinutes(3)
                },
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match F",
                    TimeStamp = DateTime.Now.AddMinutes(5)
                },
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match B",
                    TimeStamp = DateTime.Now.AddMinutes(7)
                },
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match C",
                    TimeStamp = DateTime.Now.AddMinutes(8)
                },
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match D",
                    TimeStamp = DateTime.Now.AddMinutes(10)
                },
                new Match
                {
                    Id = Guid.NewGuid(),
                    Name = "Match E",
                    TimeStamp = DateTime.Now.AddMinutes(11)
                }
            });
        }
    }
}

