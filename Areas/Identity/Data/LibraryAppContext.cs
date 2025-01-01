using LibraryApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Data;

public class LibraryAppContext : IdentityDbContext<LibraryAppUser>
{
    public LibraryAppContext(DbContextOptions<LibraryAppContext> options) : base(options) { }

    public DbSet<LibraryApp.Models.Book> Books { get; set; } = default!;
    public DbSet<LibraryApp.Models.Author> Authors { get; set; } = default!;
    public DbSet<LibraryApp.Models.Loan> Loans { get; set; } = default!;

    public void Configure(EntityTypeBuilder<LibraryAppUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
