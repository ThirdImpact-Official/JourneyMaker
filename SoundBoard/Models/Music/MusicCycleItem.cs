using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class MusicCycleItem : BaseEntity
    {
        public int Id { get; set; }
        public int MusicCycleId { get; set; }
        public MusicCycles? MusicCycle { get; set; }
        public int MusicId { get; set; }
        public Music? Music { get; set; }
        public int Position { get; set; }
    }
}
