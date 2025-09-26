using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.Service
{
    public interface ISoundPlayService
    {
        /// <summary>
        /// Engage the player on the track 
        /// </summary>
        /// <returns></returns>
        Task Play(string name);
        /// <summary>
        /// stop the player
        /// </summary>
        /// <returns></returns>
        Task Stop();

        IAudioPlayer GetPlayer();
    }
}
