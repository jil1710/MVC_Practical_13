namespace MVC_Practical_13.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Practical_13.DataContext.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Practical_13.DataContext.UserDbContext context)
        {
            context.Users.AddOrUpdate(user => user.Id, new Models.User() { Name = "Jil", DOB = Convert.ToDateTime("17-04-2001").Date, Age = 21 }, new Models.User() { Name = "Janvi", DOB = Convert.ToDateTime("10-03-2001").Date, Age = 21 });
            context.SaveChanges();
        }
    }
}
