using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SeedData
{
    public class ProjectsDataSeed
    {
        public static async Task SetProjectsDataSeed(DataContext context)
        {
            if (!context.Project.Any())
            {
                var projects = new List<Project>(){
                    new Project()
                    {
                        Name = "Crypto",
                        Description = "Crypto Prices List",
                        Status = "Pending",
                        CreatedBy = "avimatta",
                        CreatedDate = new DateTime(2021, 2 , 16)
                    }
                    , new Project()
                    {
                        Name = "Gaming",
                        Description = "Gaming Info",
                        Status = "Pending",
                        CreatedBy = "avimatta",
                        CreatedDate = new DateTime(2022, 2 , 25)
                    }
                    , new Project()
                    {
                        Name = "Stocks",
                        Description = "Stocks Prices List",
                        Status = "Pending",
                        CreatedBy = "avimatta",
                        CreatedDate = new DateTime(2021, 6 , 8)
                    }
                    , new Project()
                    {
                        Name = "AI Insights",
                        Description = "Artifical intelligence Insights",
                        Status = "Pending",
                        CreatedBy = "avimatta",
                        CreatedDate = new DateTime(2022, 1 , 28)
                    }
                };

                await context.Project.AddRangeAsync(projects);
                await context.SaveChangesAsync();

            }

            if (context.Project.Any(p => p.CreatedBy == string.Empty))
            {
                var projects = await context.Project.ToListAsync();

                projects = projects.Where(p => p.CreatedBy == string.Empty).ToList();

                if (projects.Count > 0)
                {
                    projects.ForEach(p =>
                    {
                        p.CreatedDate = DateTime.Now;
                        p.CreatedBy = "avimatta";
                    });

                    await context.Project.AddRangeAsync(projects);
                    await context.SaveChangesAsync();

                }

            }
        }
    }
}