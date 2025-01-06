using Microsoft.EntityFrameworkCore;
using SoundBoard.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<SoundFile> SoundFiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Phase> Phase { get; set; }
    public DbSet<SoundLibrary> SoundLibrary  { get; set;}
    public DbSet<SoundFiletype> SoundFiletypes { get; set; }
    public DbSet<Musicfile> Musicfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //------------------Phase
        modelBuilder.Entity<Phase>()

                    .HasKey(pe=>pe.Id);
        //------------------Music
        modelBuilder.Entity<Musicfile>()
                    .HasKey(xw=>xw.Id);

        modelBuilder.Entity<Musicfile>()
                    .HasOne(x=>x.phase)
                    .WithMany()
                    .HasForeignKey(xz=>xz.PhaseId);

        modelBuilder.Entity<Musicfile>()
                    .HasOne(x => x.soundFiletype)
                    .WithMany()
                    .HasForeignKey(xz => xz.SoundFiletypeId);

        //------------------Users
        modelBuilder.Entity<User>()
                    .HasKey(x=>x.Id);

        //------------------SoundLibrary
        modelBuilder.Entity<SoundLibrary>()
                    .HasKey(x => x.Id);

        modelBuilder.Entity<SoundLibrary>()
                    .HasOne(xs=>xs.User)
                    .WithMany(xz=>xz.SoundLibraries)
                    .HasForeignKey(xd=>xd.Id);

        //------------------SoundFile
        modelBuilder.Entity<SoundFile>()
                    .HasKey(x => x.Id);

        modelBuilder.Entity<SoundFile>()
                    .HasOne(x=>x.soundFiletype)
                    .WithMany()
                    .HasForeignKey(xd=>xd.SoundFiletypeId);

        //------------------SoundFileType
        modelBuilder.Entity<SoundFiletype>()
                    .HasKey(x=>x.Id);

        base.OnModelCreating(modelBuilder);
    }
}