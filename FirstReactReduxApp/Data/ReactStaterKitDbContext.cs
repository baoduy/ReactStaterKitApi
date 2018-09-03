using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstReactReduxApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstReactReduxApp.Data
{
    public class ReactStaterKitDbContext:DbContext
    {
        public ReactStaterKitDbContext(DbContextOptions<ReactStaterKitDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "Tuan",
                FirstName = "Tuan",
                LastName = "Nguyen",
                Email = "xuantuan93@gmail.com",
                Avatar = null
            },new User
            {
                Id = 2,
                Username = "Steven",
                FirstName = "Steven",
                LastName = "Hoang",
                Email = "baoduy2412@outlook.com",
                Avatar = null
            });
        }
        

    }
}
