namespace SoundBoard.Models;
public class Musicfile 
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string FilePath { get; set; }= string.Empty ;
    public int PhaseId { get; set; } 
    public Phase? Phase{ get; set; }
    public int SoundFiletypeId { get; set; }
    public SoundFiletype? SoundFiletype{ get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
