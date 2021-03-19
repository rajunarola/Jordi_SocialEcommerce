using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialEcommerce.Data.Seeders
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //For AspNetRoles data
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {   
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp=Guid.NewGuid().ToString()
                 },
                new IdentityRole
                {
                    Name = "Distributor",
                    NormalizedName = "DISTRIBUTOR",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }

            );
            


        }
    }
}
