namespace SoundBoard.Models;
public class User 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;  
    public string LastName { get;set;} = string.Empty;
    public string UserName { get; set;} = string.Empty;
    public string UserEmail { get; set;} =string.Empty;
    public List<SoundLibrary>? SoundLibraries{ get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}