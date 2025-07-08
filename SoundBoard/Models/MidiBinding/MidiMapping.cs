using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.MidiBinding
{
    public class MidiMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string MidiControlId { get; set; } = string.Empty;
        public int? MidiNoteStart { get; set; }
        public int? MidiNoteEnd { get; set; }
        public string TargetType { get; set; } = string.Empty;
        public string TargetValue { get; set; } = string.Empty;
        public string Parameters { get; set; } = string.Empty;
        public int? MusicId { get; set; }
        public Music? Music { get; set; }
        public Guid? SoundEffectId { get; set; }
        public SoundEffect? SoundEffect { get; set; }
    }
}
