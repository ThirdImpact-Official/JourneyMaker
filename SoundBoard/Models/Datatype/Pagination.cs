namespace SoundBoard.Models;
public class Pagination<T> 
{
    public List<T>? Data{ get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public bool Sccesss { get; set; }
    public string Message { get; set; } = string.Empty;
    public Errortype Errortype { get; set; }
}