using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.Models
{
    public class PlaylistItem: BindableObject
    {
        public int Id { get; set; }
        public static ObservableCollection<PlaylistItem> Fill_PlaylistData(ObservableCollection<PlaylistItem> Items)
        {
            for (int i = 0; i < 10; i++)
            {
                Items.Add(new PlaylistItem
                {
                    Id = i,

                });
            }
            return Items;
        }

    }

}
