using System.Linq;
using System.Threading.Tasks;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Utilities.Helper;
using Microsoft.EntityFrameworkCore;

namespace Example.CodingTask.Data.Configuration
{
    public static class CodingTaskContextExtensions
    {
        public static async Task Initialize(this CodingTaskContext context, IHashService hashService)
        {
            await context.Database.EnsureCreatedAsync();

            await InitializeUsers(context, hashService);
        }

        public static async Task InitializeUsers(CodingTaskContext context, IHashService hashService)
        {
            var currentUsers = await context.Users.ToListAsync();
            var anyNewUser = false;

            if (!currentUsers.Any())
            {
                context.Users.Add(new User
                {
                    UserName = "User1",
                    Password = await hashService.HashText("Password1")
                });

                context.Users.Add(new User
                {
                    UserName = "User2",
                    Password = await hashService.HashText("Password2")
                });

                context.Users.Add(new User
                {
                    UserName = "User3",
                    Password = await hashService.HashText("Password3")
                });

                context.Users.Add(new User
                {
                    UserName = "User4",
                    Password = await hashService.HashText("Password4")
                });

                anyNewUser = true;
            }

            if (anyNewUser)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
