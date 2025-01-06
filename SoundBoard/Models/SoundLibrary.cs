/// <summary>
/// modélise la LIbrary de l'utilisateur
/// </summary>
namespace SoundBoard.Models;
public class SoundLibrary 
{
    public int Id {get;set;}
    public int UserId {get;set;}
    public User User {get;set;}
    public string Name {get;set;}= string.Empty;
    public List<SoundFile>? soundFiles {get;set;}
    public List<Musicfile>? musicfiles{get;set;}
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}