using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketConnect.IdentityServer.Data
{
    public class AppDbContext(DbContextOptions options) :IdentityDbContext<ApplicationUser>(options);
}
