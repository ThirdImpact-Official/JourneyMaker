using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.Service
{
    public interface IHttpClientBuilder

    {
        /// <summary>
        /// allow th user to perform a Get Request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHttpClientBuilder Get(string url);
        /// <summary>
        /// allow th user to perform a Get Request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHttpClientBuilder GetPage<T>(string url, int page , int pageSize);
        /// <summary>
        /// allow a user to perform a post request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IHttpClientBuilder Post<T>(string url, T data);
        /// <summary>
        /// allow a user to perform a post request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHttpClientBuilder Post<T>(string url);
        /// <summary>
        /// allow the user to perform a put request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IHttpClientBuilder Put<T>(string url, T data);
        /// <summary>
        /// Allow a user to perform a Delete request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHttpClientBuilder Delete(string url);
        /// <summary>
        /// set the Base url 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        void SetBaseUrl(string url);
        /// <summary>
        /// Send the request For the HttpRequest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<ServiceResponse<T>> SendRequest<T>() 
            where T : class;

         
    }
}
