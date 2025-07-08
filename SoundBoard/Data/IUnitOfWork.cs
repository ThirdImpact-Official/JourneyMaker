using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Repository.Cycle;
using SoundBoard.Repository.Favorite;

namespace SoundBoard.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit a transaction
        /// </summary>
        /// <returns></returns>
        Task Commit();

        /// <summary>
        /// Rollback From a transaction
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();

        /// <summary>
        /// Begin a transaction
        /// </summary>
        void BegintransactionAsync();

        /// <summary>
        /// Execute operations within a transaction using execution strategy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operation"></param>
        /// <returns></returns>
        Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation)
            where T : BaseEntity;

        /// <summary>
        /// Execute operations within a transaction using execution strategy
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        Task ExecuteInTransactionAsync(Func<Task> operation);

        /// <summary>
        /// Get Repository by Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>()
            where T : BaseEntity;
    }
}
