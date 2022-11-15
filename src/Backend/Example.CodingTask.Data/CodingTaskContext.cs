using System;
using System.Reflection;
using System.Threading.Tasks;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Data.Configuration;
using Example.CodingTask.Utilities.Helper;
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Data
{
    public class CodingTaskContext : DbContext, ICodingTaskContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Match> Matches { get; set; }

        public virtual DbSet<UserMatch> UserMatches { get; set; }

        public CodingTaskContext(DbContextOptions<CodingTaskContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);

        public async Task Seed(IHashService hashService)
        {
            await this.Initialize(hashService);
        }
    }
}
