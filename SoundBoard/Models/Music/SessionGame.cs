using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class SessionGame : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MusicCycles>? Cycles { get; set; }
    }
}
