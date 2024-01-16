using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-MP1V9N8\\SQLEXPRESS;initial catalog=ASP_SEM7_LAB3_3;Integrated Security=False;User Id=main;Password=main;");
        }
    }
}