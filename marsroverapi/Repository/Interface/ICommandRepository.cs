public interface ICommandRepository : IRepository<Command>
{
    Command GetById(int id);
    // db methods..
}