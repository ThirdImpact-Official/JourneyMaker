using Newtonsoft.Json;
using SoundBoard.UI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoundBoard.UI.Service
{
    public class HttpClientBuilder : IHttpClientBuilder,IDisposable
     
    {
        public string BaseURl;
        public string _url;
        
        public int _page;
        public int _pageSize;

        public RequestType RequestType=RequestType.Get;
        public object Data;
        public HttpClient _client;
        private bool _disposed = false;
        public HttpClientBuilder (string baseURl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseURl);
            BaseURl = baseURl;
        }

        public IHttpClientBuilder Delete(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");

            RequestType = RequestType.Delete;
            return this;
        }

        public IHttpClientBuilder Get(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");

            RequestType = RequestType.Get;
            return this;
        }

        public IHttpClientBuilder GetPage<T>(string url, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");
            RequestType =RequestType.Get;
            _url = url;
            return this;
        }

        public IHttpClientBuilder Post<T>(string url, T data)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");

            RequestType = RequestType.Post;
            _url =url;
            if (data != null)
            {
                
                Data = data;
              
            }
            return this;
        }

        public IHttpClientBuilder Post<T>(string url)
        {
            if(string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");
            RequestType = RequestType.Post;
            _url = url;
            return this;
        }

        public IHttpClientBuilder Put<T>(string url, T data)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot be new ");

            RequestType = RequestType.Put;
            _url = url;
            if (data != null)
            {
                Data = data;
            }
            return this;
        }
        /// <summary>
        /// sendthe request To the Server
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<ServiceResponse<T>> SendRequest<T>() where T : class
        {
            StringContent jsonContent;
            HttpResponseMessage Response;
            try
            {
                switch (RequestType)
                {
                    case (RequestType.Get):
                        Response = await _client.GetAsync(_url);
                        break;
                    case (RequestType.GetPage):
                        Response = await _client.GetAsync(_url);
                        break;
                    case (RequestType.Post):
                        jsonContent = Data != null ? HandleDataTransfer(Data) : null;
                        Response = jsonContent != null ? await _client.PostAsync(_url, jsonContent)
                               : await _client.PostAsync(_url, null);
                        break;
                    case (RequestType.Put):
                        jsonContent = Data != null ? HandleDataTransfer(Data) : null;
                        Response = await _client.PutAsync(_url, jsonContent);
                        break;

                    case (RequestType.Delete):
                        Response = await _client.DeleteAsync(_url);
                        break;
                    default:
                        throw new ArgumentException();
                }
                return await HandleRequest<T>(Response);
            }
            catch (HttpRequestException ex)
            {
                return new ServiceResponse<T>() { Success = false };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>() { Success = false };
            }
        }
        /// <summary>
        /// Handle the conversion for Put and Post request 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Data"></param>
        /// <returns></returns>
        public StringContent HandleDataTransfer<T>(T Data) where T : class
        {
            return new StringContent(JsonConvert
                            .SerializeObject(Data),
                            Encoding.UTF8,
                            "application/json"
                            );
        }
        /// <summary>
        /// Handle the response interecepted
        /// </summary>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<T>> HandleRequest<T>(HttpResponseMessage responseMessage)
            where T : class
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                string body = await responseMessage.Content.ReadAsStringAsync();

                ServiceResponse<T> result = JsonConvert.DeserializeObject<ServiceResponse<T>>(body);
                return result ?? new ServiceResponse<T>() 
                    {
                        Success = true,
                        Message="the request as been proceed but no response has een received"
                    };

            }
            else
            {
                return new ServiceResponse<T>
                {
                    Message="Unable to process your request",
                    Data=null,
                    Success=false,
                };
            }
        }
        /// <summary>
        /// dispose of the instance 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _client?.Dispose();
                _disposed = true;
            }
        }
        /// <summary>
        /// allow to change the base url of The Client Builder 
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetBaseUrl(string url)
        {
            if (_client == null)
                throw new ArgumentNullException("_the client httpDoesn't exist");

            if(string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url cannot contain empty space or be null");
          _client.BaseAddress= new Uri(url); 
        }
    }
}
