using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace HireFire.Infrastructure
{
    public class HireFireDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Gig> Gigs { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskComment> TaskComments { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }  






    }
}
