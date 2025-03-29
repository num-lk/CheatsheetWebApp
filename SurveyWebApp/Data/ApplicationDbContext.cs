using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CheatsheetWebApp.Models;

namespace CheatsheetWebApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<CheatsheetWebApp.Models.Cheatsheet> Cheatsheet { get; set; } = default!;
}
