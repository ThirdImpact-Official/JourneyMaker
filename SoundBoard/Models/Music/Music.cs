using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    /*
    * This class is a model for the musics
    */
    public class Music : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public float Volumes { get; set; }
        public int Duration { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }
        public int MusicLibrairiesId { get; set; }
        public MusicLibrairies? MusicLibrairies { get; set; }
        public ICollection<MusicTag>? MusicTags { get; set; }
    }
}
