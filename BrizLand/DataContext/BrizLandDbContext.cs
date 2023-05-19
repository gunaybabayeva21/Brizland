using BrizLand.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrizLand.DataContext
{
    public class BrizLandDbContext: IdentityDbContext<AppUser>
    {
        public BrizLandDbContext(DbContextOptions<BrizLandDbContext> options) : base(options)
        {


        }


    }
    
}
