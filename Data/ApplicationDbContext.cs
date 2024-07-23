using Microsoft.EntityFrameworkCore;
using PocketBook.Models;

namespace PocketBook.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options
) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
}