using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Service.Tool
{
    public static class BussinessManager
    {
        /// <summary>
        ///  génération of a servicereponse inside the business Service
        ///  if
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ServiceResponse<TEntity> Success<TEntity>(TEntity entity)
            where TEntity : class
        {
            return new ServiceResponse<TEntity>
            {
                Success = true,
                Data = entity,
                Message = "Success operation ",
                Error = Errortype.Good,
            };
        }

        /// <summary>
        ///  generation of a serivcereponse inside the application
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ServiceResponse<TEntity> Failure<TEntity>(TEntity entity)
            where TEntity : class
        {
            return new ServiceResponse<TEntity>
            {
                Success = true,
                Data = entity,
                Message = "Success operation ",
                Error = Errortype.Good,
            };
        }
        /// <summary>
        ///  generation of a serivcereponse inside the application
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ServiceResponse<TEntity> Failure<TEntity>(Errortype Errortype, string message)
            where TEntity : class
        {
            return new ServiceResponse<TEntity>
            {
                Success = true,
                Data = null,
                Message = "Success operation ",
                Error = Errortype,
            };
        }
       
    }
}
