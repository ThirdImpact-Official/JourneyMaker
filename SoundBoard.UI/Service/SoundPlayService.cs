using Plugin.Maui.Audio;

namespace SoundBoard.UI.Service
{
    class SoundPlayService : ISoundPlayService,IDisposable
    {
        private readonly AudioManager _audioManager;
        private IAudioPlayer _player;
        public SoundPlayService(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }
        
        public void Dispose()
        {
            if (_player != null)
            {
                _player.Dispose();
            }
        }

        public IAudioPlayer GetPlayer() => this._player;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task Play(string name)
        {
            try
            {
                if (await FileSystem.AppPackageFileExistsAsync(name))
                    throw new FileNotFoundException(name + "doesn't exist");

                var stream = await FileSystem.OpenAppPackageFileAsync(name);
                _player = _audioManager.CreatePlayer(stream);
                _player.Play(); 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task Stop()
        {
            try
            {
                if (_player != null)
                {
                    _player.Stop();
                }
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
