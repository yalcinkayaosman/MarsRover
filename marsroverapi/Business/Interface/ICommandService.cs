public interface ICommandService
{
    ResultObjectDto MoveRover(RoverCommandDto roverCommandDto);
    Command GetById(int id);
}