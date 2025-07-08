using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SoundBoard.Models.Favorite;
using SoundBoard.Models.keyBinding;
using SoundBoard.Models.MidiBinding;

namespace SoundBoard.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserTag>? UserTags { get; set; }
        public ICollection<MusicLibrairies>? MusicLibrairies { get; set; }
        public ICollection<SoundEffectLibrary>? SoundEffectLibraries { get; set; }
        public ICollection<SessionGame>? SessionGames { get; set; }
        public ICollection<FavoriteMusic>? FavoriteMusics { get; set; }
        public ICollection<FavoriteSoundEffect>? FavoriteSoundEffects { get; set; }
        public ICollection<KeyBoardMapping>? KeyBoardMappings { get; set; }
        public ICollection<MidiMapping>? MidiMappings { get; set; }
        public UserSettings? UserSettings { get; set; } // <==>
        public ICollection<Playlist>? Playlists { get; set; }
    }
}
