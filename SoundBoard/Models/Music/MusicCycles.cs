using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class MusicCycles : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool AutoPlay { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<MusicCycleItem>? Items { get; set; }
        public ICollection<MusicCycleTransition>? TransitionFrom { get; set; }
        public ICollection<MusicCycleTransition>? TransitionTo { get; set; }
    }
}
