namespace RedMood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RedMood.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RedMood.Models.RedMoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RedMood.Models.RedMoodContext context)
        {
            //  This method will be called after migrating to the latest version.
                        
            context.Moods.AddOrUpdate(
                  p => p.Id,
                  new Moods { Id = 1, Description = "~/content/Images/happysmiley.gif" },
                  new Moods { Id = 2, Description = "~/content/Images/sadsmiley.gif" }
                );
        }
    }
}
