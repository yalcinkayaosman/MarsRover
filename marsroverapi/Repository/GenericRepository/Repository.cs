using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

public class Repository<T> : IRepository<T> where T : AbstractEntity
{
    private readonly IMongoRepository<T> _mongoRepository;
    public Repository(IMongoRepository<T> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    public ResultObjectDto Create(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(string id)
    {
        ObjectId objectId = GetObjectId(id);
        return _mongoRepository.GetCollection().Find(x => x.Id == objectId).FirstOrDefault();
    }

    private ObjectId GetObjectId(string id)
    {
        ObjectId internalId;
        if (!ObjectId.TryParse(id, out internalId))
            internalId = ObjectId.Empty;

        return internalId;
    }

    // and other methods..
}