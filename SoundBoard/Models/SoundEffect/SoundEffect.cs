using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class SoundEffect : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public int StartTime { get; set; } = 0;
        public int? EndTime { get; set; }
        public int SoundEffectLibraryId { get; set; }
        public SoundEffectLibrary? SoundEffectLibrary { get; set; }
        public ICollection<SoundEffectTag>? SoundEffectTags { get; set; }
    }
}
