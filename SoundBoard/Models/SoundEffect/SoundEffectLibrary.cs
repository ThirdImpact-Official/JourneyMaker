using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class SoundEffectLibrary : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<SoundEffect>? SoundEffects { get; set; }
    }
}
