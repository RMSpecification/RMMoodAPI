namespace MoodAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MoodAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoodAPI.Models.MoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoodAPI.Models.MoodContext context)
        {

            //  This method will be called after migrating to the latest version.

            context.Moods.AddOrUpdate(
                  p => p.Id,
                  new Mood { Id = 1, Description = "Happy" },
                  new Mood { Id = 2, Description = "Ok" },
                  new Mood { Id = 3, Description = "Sad" }
                );
        }
    }
}
