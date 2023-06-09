﻿using TradingBot.Core.Domain;
using TradingBot.Core.Specification;

namespace TradingBot.Core.Repository
{
    public interface IRepository
    {
        Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>;

        Task<TEntity?> FindByExpressionAsync<TEntity>(IEqualSpecification<TEntity> specification) where TEntity :
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>;

        Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase,
            IAggregateRoot, IEqualSpecification<TEntity>;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase,
            IAggregateRoot, IEqualSpecification<TEntity>;

        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>;

        Task<TEntity> ImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>;

        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>;
    }
}
