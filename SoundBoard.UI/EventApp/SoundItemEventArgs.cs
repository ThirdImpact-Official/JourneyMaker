using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.EventApp
{
    public class SoundItemEventArgs: EventArgs
    {
        public SoundItem SoundItem { get; }

        public SoundItemEventArgs(SoundItem soundItem)
        {
            SoundItem = soundItem; 
        }
    }
}
