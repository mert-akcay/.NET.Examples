using Identity101.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity101.Data;

public sealed class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public MyContext(DbContextOptions options) : base(options)
    {

    }
}
