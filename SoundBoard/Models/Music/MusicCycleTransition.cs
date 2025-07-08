using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class MusicCycleTransition : BaseEntity
    {
        public int Id { get; set; } //cycles suivant
        public int NextCyclesId { get; set; }
        public MusicCycles? NextCycles { get; set; } //précédent cycles
        public int PreviousCyclesId { get; set; }
        public MusicCycles? PreviousCycles { get; set; }
        public int Priority { get; set; }
        public string ConditionExpression { get; set; } = string.Empty;
    }
}
