using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.EventApp
{
    public class SoundGridEventArg
    {
        public SoundGrid SoundGrid { get; }
        public SoundGridEventArg(SoundGrid soundGrid)
        {
            SoundGrid = soundGrid;
        }
    }
}
