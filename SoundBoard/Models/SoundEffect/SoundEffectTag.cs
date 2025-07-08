using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class SoundEffectTag
    {
        public int SoundEffectId { get; set; }
        public SoundEffect? SoundEffect { get; set; }
        public int TagId { get; set; }
        public UserTags? Tag { get; set; }
    }
}
