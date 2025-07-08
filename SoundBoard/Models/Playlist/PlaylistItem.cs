using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class PlaylistItem : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public int MusicId { get; set; }
        public Music? Music { get; set; }

        public int SoundEffectId { get; set; }
        public SoundEffect? SoundEffect { get; set; }
    }
}
