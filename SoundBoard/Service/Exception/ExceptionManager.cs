using SoundBoard.Models;

namespace SoundBoard.Service.Exception
{
    public static class ExceptionManager<T> where T : class
    {
        public static ServiceResponse<T> DataError<T>(Errortype Errortype, string message)
        {
            return new ServiceResponse<T> 
            { 
                Error = Errortype,
                Message = message,
                Sccesss = false, 
                Data = default
            };

        }
    }
}
