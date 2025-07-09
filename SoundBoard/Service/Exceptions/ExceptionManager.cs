using SoundBoard.Models;

namespace SoundBoard.Service.Exceptions
{
    public static class ExceptionManager<T>
        where T : class
    {
        public static ServiceResponse<T> DataError<T>(Errortype Errortype, string message)
        {
            return new ServiceResponse<T> 
            { 
                Error = Errortype,
                Message = message,
                Success = false,
                Data = default ,
            };
        }
    }
}
