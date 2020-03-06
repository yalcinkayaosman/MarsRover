public class CommandRepository : Repository<Command>, ICommandRepository
{
    public CommandRepository(IMongoRepository<Command> genericRepository) : base(genericRepository)
    {
    }

    public Command GetById(int id)
    {
        throw new System.NotImplementedException();
    }

    // db methods..
}