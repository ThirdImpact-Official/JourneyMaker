using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.Favorite
{
    public class FavoriteSoundEffect : BaseEntity
    {
        public int SoundEffectId { get; set; }
        public SoundEffect? SoundEffect { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
