using MongoDB.Driver;

public interface IMongoRepository<T>
{
    IMongoCollection<T> GetCollection();
}