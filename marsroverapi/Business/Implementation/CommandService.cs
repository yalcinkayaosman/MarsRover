using System;

public class CommandService : ICommandService
{
    private readonly ICommandRepository _commandRepository;

    public CommandService(ICommandRepository rolePageRepository)
    {
        _commandRepository = rolePageRepository;
    }

    public Command GetById(int id)
    {
        return _commandRepository.GetById(id);
    }

    public ResultObjectDto MoveRover(RoverCommandDto roverCommandDto)
    {
        ResultObjectDto result = new ResultObjectDto();
        Point currentPoint = new Point();
        currentPoint.CoordinateX = roverCommandDto.StartCoordinateX;
        currentPoint.CoordinateY = roverCommandDto.StartCoordinateY;
        currentPoint.Direction = GetDirection(roverCommandDto.StartDirection.ToUpper());

        char[] commandList = roverCommandDto.Commands.ToUpper().ToCharArray();
        foreach (var command in commandList)
        {
            if (command == 'L')
            {
                currentPoint.Direction = TurnLeft(currentPoint.Direction);
            }
            else if (command == 'R')
            {
                currentPoint.Direction = TurnRight(currentPoint.Direction);
            }
            else if (command == 'M')
            {
                currentPoint = Move(currentPoint);
            }
            else
            {
                result.Message = "Tanımsız bir komut girildiği için rover kilitlendi.";
                result.IsSuccess = false;
                break;
            }
        }

        if (currentPoint.CoordinateY > roverCommandDto.DimensionY || currentPoint.CoordinateX > roverCommandDto.DimensionX)
        {
            result.Message = "Rover uzay boşluğuna düştü.";
            result.IsSuccess = false;
        }

        result.Message = "Görev başarıyla tamamlandı.";
        result.IsSuccess = true;
        result.Result = String.Format("Konum : {0}-{1}-{2}", currentPoint.CoordinateX, currentPoint.CoordinateY, SetDirection(currentPoint.Direction));
        return result;
    }

    private int TurnLeft(int currentPointDirection)
    {
        if (currentPointDirection - 1 < (int)Direction.North)
        {
            currentPointDirection = (int)Direction.West;
        }
        else
        {
            currentPointDirection = currentPointDirection - 1;
        }
        return currentPointDirection;
    }

    private int TurnRight(int currentPointDirection)
    {
        if (currentPointDirection + 1 > (int)Direction.West)
        {
            currentPointDirection = (int)Direction.North;
        }
        else
        {
            currentPointDirection = currentPointDirection + 1;
        }
        return currentPointDirection;
    }

    private Point Move(Point currentPoint)
    {
        if (currentPoint.Direction == (int)Direction.North)
        {
            currentPoint.CoordinateY++;
        }
        else if (currentPoint.Direction == (int)Direction.East)
        {
            currentPoint.CoordinateX++;
        }
        else if (currentPoint.Direction == (int)Direction.South)
        {
            currentPoint.CoordinateY--;
        }
        else if (currentPoint.Direction == (int)Direction.West)
        {
            currentPoint.CoordinateX--;
        }

        return currentPoint;
    }

    private int GetDirection(string direction)
    {
        if (direction == "N")
        {
            return 1;
        }
        else if (direction == "E")
        {
            return 2;
        }
        else if (direction == "S")
        {
            return 3;
        }
        else if (direction == "W")
        {
            return 4;
        }

        return 0;
    }

    private string SetDirection(int direction)
    {
        if (direction == 1)
        {
            return "N";
        }
        else if (direction == 2)
        {
            return "E";
        }
        else if (direction == 3)
        {
            return "S";
        }
        else if (direction == 4)
        {
            return "W";
        }

        return "Black Hole";
    }
}