using MVC_Practical_13.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Practical_13.DataContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("name=CRUD")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}