using MVC_Practical_13_Test2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Practical_13_Test2.DataContext
{
    public class ComanyDbContext : DbContext
    {
        public ComanyDbContext() : base("Data Source=SF-CPU-312\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True;Connect Timeout=30;Encrypt=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ComanyDbContext>());
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}