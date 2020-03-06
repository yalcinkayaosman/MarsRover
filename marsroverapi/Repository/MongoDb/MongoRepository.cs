using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class MongoRepository<T> : IMongoRepository<T> where T : AbstractEntity
{

    private readonly IMongoDatabase _database = null;

    public MongoRepository(IOptions<MongoSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<T> GetCollection()
    {
        return _database.GetCollection<T>(typeof(T).Name);
    }
}