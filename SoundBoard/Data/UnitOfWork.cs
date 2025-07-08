using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SoundBoard.Repository.Cycle;
using SoundBoard.Repository.Favorite;

namespace SoundBoard.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDbContextTransaction? transaction;
        #region Favorite
        private readonly IFavoriteMusicRepository? favoriteMusicRepository;
        private readonly IFavoriteSoundEffectRepository? favoriteSoundEffectRepository;
        #endregion

        #region Music
        private readonly IMusicLibraryRepository? musicLibraryRepository;
        private readonly IMusicRepository? musicRepository;
        #endregion

        #region SoundEffect
        private readonly ISoundEffectLibraryRepository? soundEffectLibraryRepository;
        private readonly ISoundEffectRepository? soundEffectRepository;
        #endregion

        #region Tag

        private readonly ITagRepository? tagRepository;
        #endregion

        #region Cycle
        private readonly IMusicCycleRepository? musicCycleRepository;
        private readonly IMusicCycleTransitionRepository? musicCycleTransitionRepository;
        private readonly IMusicCycleItemRepository? musicCycleItemRepository;
        #endregion

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IFavoriteMusicRepository FavoriteMusicRepository =>
            favoriteMusicRepository ?? new FavoriteMusicRepository(_dataContext);
        public IFavoriteSoundEffectRepository FavoriteSoundEffectRepository =>
            favoriteSoundEffectRepository ?? new FavoriteSoundEffectRepository(_dataContext);

        public IMusicLibraryRepository MusicLibraryRepository =>
            musicLibraryRepository ?? new MusicLibraryRepository(_dataContext);
        public IMusicRepository MusicRepository =>
            musicRepository ?? new MusicRepository(_dataContext);

        public ISoundEffectLibraryRepository SoundEffectLibraryRepository =>
            soundEffectLibraryRepository ?? new SoundEffectLibraryRepository(_dataContext);
        public ISoundEffectRepository SoundEffectRepository =>
            soundEffectRepository ?? new SoundEffectRepository(_dataContext);

        public ITagRepository TagRepository => tagRepository ?? new TagRepository(_dataContext);

        public IMusicCycleRepository MusicCycleRepository =>
            musicCycleRepository ?? new MusicCycleRepository(_dataContext);
        public IMusicCycleTransitionRepository MusicCycleTransitionRepository =>
            musicCycleTransitionRepository ?? new MusicCycleTransitionRepository(_dataContext);
        public IMusicCycleItemRepository MusicCycleItemRepository =>
            musicCycleItemRepository ?? new MusicCycleItemRepository(_dataContext);

        /// <summary>
        /// Begin a transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void BegintransactionAsync()
        {
            try
            {
                transaction = _dataContext.Database.BeginTransaction();
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Unable to begin a new transaction");
            }
        }

        /// <summary>
        /// Commit a transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Commit()
        {
            try
            {
                await _dataContext.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Unable to commit transaction");
            }
        }

        /// <summary>
        /// dispose of the unit of work
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Execute operations within a transaction using execution strategy with return value
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="operation">The operation to execute within a transaction</param>
        /// <returns>The result of the operation</returns>
        public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation)
            where T : BaseEntity
        {
            IExecutionStrategy strategy = _dataContext.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync<T>(async () =>
            {
                using IDbContextTransaction transaction =
                    await _dataContext.Database.BeginTransactionAsync();
                try
                {
                    T result = await operation();
                    await _dataContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        /// <summary>
        /// Execute operations within a transaction using execution strategy
        /// </summary>
        /// <param name="operation">The operation to execute within a transaction</param>
        /// <returns></returns>
        public async Task ExecuteInTransactionAsync(Func<Task> operation)
        {
            IExecutionStrategy strategy = _dataContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using IDbContextTransaction transaction =
                    await _dataContext.Database.BeginTransactionAsync();
                try
                {
                    await operation();
                    await _dataContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        /// <summary>
        /// Rollback From a transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task RollbackAsync()
        {
            try
            {
                await _dataContext.Database.RollbackTransactionAsync();
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Unable to rollback transaction");
            }
        }

        /// <summary>
        /// Get Repository by Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> GetRepository<T>()
            where T : BaseEntity
        {
            return new Repository<T>(_dataContext);
        }
    }
}
