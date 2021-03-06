using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //public static ApplicationDbContext Create()
    //{
    //    return new ApplicationDbContext();
    //}

    public DbSet<Note> Notes { get; set; }

}