using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoundBoard.Service.Tool
{
    public static class HttpManager
    {
        /// <summary>
        /// return a bad error For the controller in order to propluy handle the error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Exception"></param>
        /// <returns></returns>
        public static Task<ActionResult<ServiceResponse<T>>> BadError<T>(Exception Exception)
            where T : class
        {
            try
            {
                ServiceResponse<T> response = new ServiceResponse<T>();
                response.Success = false;
                response.Message = Exception.Message;
                return Task.FromResult<ActionResult<ServiceResponse<T>>>(
                    new BadRequestObjectResult(response)
                );
            }
            catch (Exception)
            {
                return Task.FromResult<ActionResult<ServiceResponse<T>>>(
                    new BadRequestObjectResult(
                        new ServiceResponse<T>
                        {
                            Success = false,
                            Message = "Bad request"
                        }
                    )
                );
            }
        }
        /// <summary>
        /// return a bad error For the controller in order to propluy handle the error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Exception"></param>
        /// <returns></returns>
        public static Task<ActionResult<Pagination<T>>> BadPageError<T>(Exception Exception)
            where T : class
        {
            try
            {
                Pagination<T> response = new Pagination<T>();
                response.Success = false;
                response.Message = Exception.Message;
                return Task.FromResult<ActionResult<Pagination<T>>>(
                    new BadRequestObjectResult(response)
                );
            }
            catch (Exception)
            {
                return Task.FromResult<ActionResult<Pagination<T>>>(
                    new BadRequestObjectResult(
                        new ServiceResponse<T> { Success = false, Message = "Bad request" }
                    )
                );
            }
        }

        /// <summary>
        /// Return a bad error for the controller in order to properly handle the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceResponse">The service response.</param>
        /// <returns>The action result.</returns>
        public static ActionResult<ServiceResponse<T>> HandleRequest<T>(
            ServiceResponse<T> serviceResponse
        )
        {
            return serviceResponse.Error switch
            {
                Errortype.Good => new OkObjectResult(serviceResponse),
                Errortype.Bad => new BadRequestObjectResult(serviceResponse),
                Errortype.Null => new NotFoundObjectResult(serviceResponse),
                Errortype.Other => new BadRequestObjectResult(serviceResponse),
                _ => new BadRequestObjectResult(serviceResponse),
            };
        }

        /// <summary>
        /// Return a bad error for the controller in order to properly handle the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceResponse">The service response.</param>
        /// <returns>The action result.</returns>
        public static ActionResult<Pagination<T>> HandleRequest<T>(Pagination<T> serviceResponse)
        {
            return serviceResponse.Errortype switch
            {
                Errortype.Good => new OkObjectResult(serviceResponse),
                Errortype.Bad => new BadRequestObjectResult(serviceResponse),
                Errortype.Null => new NotFoundObjectResult(serviceResponse),
                Errortype.Other => new BadRequestObjectResult(serviceResponse),
                _ => new BadRequestObjectResult(serviceResponse),
            };
        }
    }
}
