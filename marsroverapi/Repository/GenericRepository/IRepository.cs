using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRepository<T>
{
    T GetById(string id);

    List<T> GetAll();

    IEnumerable<T> Get(Expression<Func<T, bool>> expression);

    ResultObjectDto Create(T item);

    // and other methods..
}