using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    /*
    * This class is a model for the user tags
    * tags are used to define sound effect and music by the users
    * in order to identify them in his own way
    */
    public class UserTag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<MusicTag>? MusicTags { get; set; }
    }
}
