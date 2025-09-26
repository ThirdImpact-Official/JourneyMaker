using SoundBoard.UI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.Models;

public class ServiceResponse<T> where T : class
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public ErrorType ErrorType { get; set; }
    public bool Success { get; set; }
   
}
