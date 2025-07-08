using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class MusicTag : BaseEntity
    {
        public int MusicId { get; set; }
        public Music? Music { get; set; }
        public int TagId { get; set; }
        public UserTag? UserTag { get; set; }
    }
}
