﻿using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext) =>
            RepositoryContext = repositoryContext; //instantiating same as contructor

        // we can see the trackChanges parameter. We are going to use 
        //  it to improve our read-only query performance.When it’s set to false, we
        //  attach the AsNoTracking method to our query to inform EF Core that it
        //doesn’t need to track changes for the required entities.This greatly
        //improves the speed of a query.
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
           bool trackChanges) =>
             !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() : RepositoryContext.Set<T>().Where(expression);

        public async Task Create(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
        }
        public async Task Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity); // Attach the entity to the context if not already attached
            await RepositoryContext.SaveChangesAsync();

        }
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
           
        }

    }
}
