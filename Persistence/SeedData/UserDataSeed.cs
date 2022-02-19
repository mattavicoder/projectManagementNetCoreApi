using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence.SeedData
{
    public class UserDataSeed
    {
        public static async Task SetUserDataSeed(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {

                var userList = new List<AppUser>(){
                    new AppUser(){DisplayName = "Jhon Doe", UserName = "johndoe", Email = "johndoe@test.com", Bio = ""},
                    new AppUser(){DisplayName = "Creed", UserName = "creed", Email = "creed@test.com", Bio = ""},
                    new AppUser(){DisplayName = "Da Vinci", UserName = "davinci", Email = "davinci@test.com", Bio = ""},
                    new AppUser(){DisplayName = "Lee", UserName = "lee", Email = "lee@test.com", Bio = ""}
                };

                foreach (var user in userList)
                {
                    await userManager.CreateAsync(user, "Qwerty@123");
                }
            }

        }
    }
}