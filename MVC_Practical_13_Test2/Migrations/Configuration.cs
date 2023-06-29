namespace MVC_Practical_13_Test2.Migrations
{
    using MVC_Practical_13_Test2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Practical_13_Test2.DataContext.ComanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Practical_13_Test2.DataContext.ComanyDbContext";
        }

        protected override void Seed(MVC_Practical_13_Test2.DataContext.ComanyDbContext context)
        {
            //  seeding initial data for practice operations
            context.Designations.AddOrUpdate(desg => desg.Id, new Designation() { Designations = "Software Developer" }, new Designation() { Designations = "Lead Engineer" });


            context.Employees.AddOrUpdate
                    (emp => emp.Id,
                    new Employee() { FirstName = "Jil", LastName = "Patel", PhoneNumber = "9898989898", Salary = 999999, DOB = Convert.ToDateTime("17/04/2001").Date, Address = "Anand", DesignationId = 1 },
                    new Employee() { FirstName = "Bhavin", LastName = "Kareliya", PhoneNumber = "9999999999", Salary = 999999, DOB = Convert.ToDateTime("17/04/2001").Date, Address = "Rajkot", DesignationId = 2 });

            context.SaveChanges();
        }
    }
}
