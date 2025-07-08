using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.keyBinding
{
    public class KeyBoardMapping : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string KeyCode { get; set; } = string.Empty;
        public int? MusicId { get; set; }
        public Music? Music { get; set; }
        public int? SoundEffectId { get; set; }
        public SoundEffect? SoundEffect { get; set; }
    }
}
