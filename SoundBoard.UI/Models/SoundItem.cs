using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundBoard.UI.Models
{
    public class SoundItem : INotifyPropertyChanged
    {
        private string? _name;
        private string? _description;
        private string? _isPLaying;

        public string Name {
            get => _name;
            set { 
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Description 
        {
            get => _description; 
            set {
                _description = value;
                OnPropertyChanged();
            }
        }
        public bool IsPLaying
        {
            get => IsPLaying;
            set
            {
                IsPLaying = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand PlayCommand { get; set; }
        /// <summary>
        /// play sound 
        /// </summary>
        private void Playsound()
        {
            IsPLaying= !IsPLaying;
            Console.WriteLine($"PlaySound:{_name}");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
