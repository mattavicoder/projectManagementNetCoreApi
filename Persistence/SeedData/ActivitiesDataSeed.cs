using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.SeedData
{
    public class ActivitiesDataSeed
    {
        public static async Task SetActivitesData(DataContext context){

            if(!context.Activities.Any()){

                var activites = new List<Activity>(){
                    new Activity(){
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Category = "drinks",
                        City = "London",
                        Description = "Activity 2 months ago",
                        Venue = "Pub"
                    },
                     new Activity(){
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Category = "culture",
                        City = "Paris",
                        Description = "Activity 1 month ago",
                        Venue = "Louvre"
                    },
                     new Activity(){
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Category = "music",
                        City = "London",
                        Description = "Activity 1 month in future",
                        Venue = "Natural History Musem"
                    },
                     new Activity(){
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Category = "music",
                        City = "London",
                        Description = "Activity 2 months in future",
                        Venue = "02 Arena"
                    },
                     new Activity(){
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Category = "drinks",
                        City = "London",
                        Description = "Activity 3 months in future",
                        Venue = "Another pub"
                    },
                     new Activity(){
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Category = "drinks",
                        City = "London",
                        Description = "Activity 4 months in future",
                        Venue = "Yet another pub"
                    },
                     new Activity(){
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Category = "drinks",
                        City = "London",
                        Description = "Activity 5 months in future",
                        Venue = "Just another pub"
                    },
                     new Activity(){
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Category = "music",
                        City = "London",
                        Description = "Activity 6 months in future",
                        Venue = "Roundhouse Camden"
                    }
                };

                await context.Activities.AddRangeAsync(activites);
                await context.SaveChangesAsync();
            }
        }
    }
}