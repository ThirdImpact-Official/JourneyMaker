/// <summary>
/// MOdélise le type de Fichier Sonore du Sound Board
/// </summary>
/// 
namespace SoundBoard.Models;
public class SoundFile
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string FilePath { get; set; }= string.Empty ;
    public int SoundFiletypeId { get; set; }
    public SoundFiletype? SoundFiletype{ get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}