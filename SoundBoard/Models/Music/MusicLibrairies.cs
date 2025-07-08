using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    /**
    * This class is a model for the music librairies
    * this is the list of the music librairies of a user 
    */
    public class MusicLibrairies : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //appartient a un utilisateur
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        //posséde une liste de musics
        public List<Music>? Musics { get; set; } = new List<Music>();
    }
}
