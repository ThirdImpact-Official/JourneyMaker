using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.Favorite
{
    public class FavoriteMusic : BaseEntity
    {
        public int MusicId { get; set; }
        public Music? Music { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
