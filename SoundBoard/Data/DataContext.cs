using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoundBoard.Models.Favorite;
using SoundBoard.Models.keyBinding;
using SoundBoard.Models.MidiBinding;

namespace SoundBoard.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<UserSettings> UserSettings { get; set; }
    public DbSet<MusicLibrairies> MusicLibrairies { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<MusicCycles> MusicCycles { get; set; }
    public DbSet<MusicCycleItem> MusicCycleItems { get; set; }
    public DbSet<MusicCycleTransition> MusicCycleTransitions { get; set; }
    public DbSet<MusicTag> MusicTags { get; set; }
    public DbSet<SessionGame> SessionGames { get; set; }
    public DbSet<UserTag> UserTags { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<PlaylistItem> PlaylistItems { get; set; }
    public DbSet<SoundEffect> SoundEffects { get; set; }
    public DbSet<SoundEffectTag> SoundEffectTags { get; set; }
    public DbSet<SoundEffectLibrary> SoundEffectLibraries { get; set; }
    public DbSet<KeyBoardMapping> KeyBoardMappings { get; set; }
    public DbSet<MidiMapping> MidiMappings { get; set; }
    public DbSet<FavoriteMusic> FavoriteMusic { get; set; }
    public DbSet<FavoriteSoundEffect> FavoriteSoundEffects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<UserTag>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<UserTag>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserTags)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<MusicTag>().HasKey(x => new { x.MusicId, x.TagId });

        _ = modelBuilder
            .Entity<MusicTag>()
            .HasOne(sd => sd.Music)
            .WithMany(sd => sd.MusicTags)
            .HasForeignKey(sd => sd.MusicId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder
            .Entity<MusicTag>()
            .HasOne(sd => sd.UserTag)
            .WithMany(sd => sd.MusicTags)
            .HasForeignKey(sd => sd.TagId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<Music>().HasKey(x => x.Id);

        _ = modelBuilder.Entity<MusicLibrairies>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<Music>()
            .HasOne(x => x.MusicLibrairies)
            .WithMany(x => x.Musics)
            .HasForeignKey(x => x.MusicLibrairiesId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<MusicCycles>().HasKey(x => x.Id);

        _ = modelBuilder.Entity<MusicCycleItem>().HasKey(x => x.Id);
        // Cyclesitem to cycles
        _ = modelBuilder
            .Entity<MusicCycleItem>()
            .HasOne(x => x.MusicCycle)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.MusicCycleId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<MusicCycleTransition>().HasKey(x => x.Id);
        //transition to cycles
        _ = modelBuilder
            .Entity<MusicCycleTransition>()
            .HasOne(x => x.NextCycles)
            .WithMany(x => x.TransitionTo)
            .HasForeignKey(x => x.NextCyclesId)
            .OnDelete(DeleteBehavior.Restrict);

        //transition From cycles
        _ = modelBuilder
            .Entity<MusicCycleTransition>()
            .HasOne(x => x.PreviousCycles)
            .WithMany(x => x.TransitionFrom)
            .HasForeignKey(x => x.PreviousCyclesId)
            .OnDelete(DeleteBehavior.Restrict);
        //playlist to user
        _ = modelBuilder.Entity<Playlist>().HasKey(x => x.Id);
        _ = modelBuilder
            .Entity<Playlist>()
            .HasOne(x => x.User)
            .WithMany(x => x.Playlists)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<PlaylistItem>().HasKey(x => x.Id);
        //playlistitem to playlist
        _ = modelBuilder
            .Entity<PlaylistItem>()
            .HasOne(x => x.Playlist)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.PlaylistId)
            .OnDelete(DeleteBehavior.Restrict);
        // Soundeffect--------------
        _ = modelBuilder.Entity<SoundEffectLibrary>().HasKey(x => x.Id);

        _ = modelBuilder.Entity<SoundEffect>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<SoundEffect>()
            .HasOne(x => x.SoundEffectLibrary)
            .WithMany(x => x.SoundEffects)
            .HasForeignKey(x => x.SoundEffectLibraryId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<SoundEffectTag>().HasKey(x => new { x.SoundEffectId, x.TagId });

        _ = modelBuilder
            .Entity<SoundEffectTag>()
            .HasOne(x => x.SoundEffect)
            .WithMany(x => x.SoundEffectTags)
            .HasForeignKey(x => x.SoundEffectId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<KeyBoardMapping>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<KeyBoardMapping>()
            .HasOne(sd => sd.User)
            .WithMany(sd => sd.KeyBoardMappings)
            .HasForeignKey(sd => sd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<MidiMapping>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<MidiMapping>()
            .HasOne(sd => sd.User)
            .WithMany(sd => sd.MidiMappings)
            .HasForeignKey(sd => sd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        _ = modelBuilder.Entity<FavoriteMusic>().HasKey(x => new { x.MusicId, x.UserId });

        _ = modelBuilder
            .Entity<FavoriteSoundEffect>()
            .HasKey(x => new { x.SoundEffectId, x.UserId });

        _ = modelBuilder
            .Entity<FavoriteMusic>()
            .HasOne(sd => sd.Music)
            .WithMany()
            .HasForeignKey(sd => sd.MusicId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = modelBuilder.Entity<SessionGame>().HasKey(x => x.Id);

        _ = modelBuilder
            .Entity<SessionGame>()
            .HasOne(sd => sd.User)
            .WithMany(sd => sd.SessionGames)
            .HasForeignKey(sd => sd.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
