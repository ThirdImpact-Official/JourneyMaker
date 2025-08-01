
namespace SoundBoard.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string? Message { get; set; } = string.Empty;
    public Errortype? Error { get; set; } = Errortype.Good;
}
