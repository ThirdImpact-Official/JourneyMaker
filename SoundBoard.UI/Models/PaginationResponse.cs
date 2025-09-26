using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.Models
{
    public class PaginationResponse<T>
    { 
        public List<T>? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }= string.Empty;
        
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
