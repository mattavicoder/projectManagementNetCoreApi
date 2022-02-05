using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.SeedData
{
    public class UserDataSeed
    {
        public static async Task SetUserDataSeed(DataContext context)
        {
            if(!context.User.Any())
            {
                var users = new List<Domain.User>(){
                    new Domain.User(){
                        Name = "John",
                        FirstName = "John",
                        LastName = "Snow"
                    },
                    new Domain.User(){
                        Name = "Aloy",
                        FirstName = "Aloy",
                        LastName = "Horizon"
                    },
                    new Domain.User(){
                        Name = "Evior",
                        FirstName = "Evior",
                        LastName = "Creed"
                    },
                    new Domain.User(){
                        Name = "Jin",
                        FirstName = "Jin",
                        LastName = "Sakai"
                    }
                };

                
                await context.User.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

        }
    }
}