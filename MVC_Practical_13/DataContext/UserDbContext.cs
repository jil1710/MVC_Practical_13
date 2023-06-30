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
        public UserDbContext() : base("Data Source=SF-CPU-312\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}