﻿using BizLand.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BizLand.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Cart>Carts { get; set; }
        public DbSet<Setting>Settings { get; set; }
    }
}
