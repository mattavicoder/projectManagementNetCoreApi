using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.SeedData
{
    public class ProjectsDataSeed
    {
        public static async Task SetProjectsDataSeed(DataContext context) 
        {
            if(!context.Project.Any())
            {
                var projects = new List<Project>(){
                    new Project() 
                    {
                        Name = "Crypto",
                        Description = "Crypto Prices List",
                        Status = "Pending"
                    }
                    , new Project() 
                    {
                        Name = "Gaming",
                        Description = "Gaming Info",
                        Status = "Pending"
                    }
                    , new Project() 
                    {
                        Name = "Stocks",
                        Description = "Stocks Prices List",
                        Status = "Pending"
                    }
                    , new Project() 
                    {
                        Name = "AI Insights",
                        Description = "Artifical intelligence Insights",
                        Status = "Pending"
                    }
                };

                await context.Project.AddRangeAsync(projects);
                await context.SaveChangesAsync();

            }
        }
    }
}