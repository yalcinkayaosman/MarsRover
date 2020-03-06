public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IMongoRepository<User> genericRepository) : base(genericRepository)
    {
    }

    // db methods..
}