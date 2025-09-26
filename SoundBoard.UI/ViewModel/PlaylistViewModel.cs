using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.ViewModel
{
    public  class PlaylistViewModel : BindableObject
    {
        public ObservableCollection<PlaylistItem> Items { get; set; }

        public PlaylistViewModel() 
        {
            Items = new ObservableCollection<PlaylistItem>();
            Items = PlaylistItem.Fill_PlaylistData(Items);
        }
    }
}
