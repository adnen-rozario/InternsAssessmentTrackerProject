﻿using InternsAssessment.Entities.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InternsAssessment.Entities.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected IATrackerDbContext RepositoryContext { get; set; }

        public Repository(IATrackerDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,string includeProperties = "")
        {
            IQueryable<T> query = this.RepositoryContext.Set<T>().Where(expression);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            query = query.AsNoTracking();

            return query;
           // return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(object id)
        {
            try
            {
                T entity = this.RepositoryContext.Set<T>().Find(id);
                this.Delete(entity);
            }
            catch (System.AggregateException)
            {

            }
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }        

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
    }
}