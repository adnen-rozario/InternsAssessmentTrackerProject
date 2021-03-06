﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace InternsAssessment.Entities.Repository
{

    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, string includeProperties = "");
        void Create(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Save();
    }
}


