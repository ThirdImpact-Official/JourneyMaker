using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoundBoard.Data;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        base.OnModelCreating(modelBuilder);
    }
}