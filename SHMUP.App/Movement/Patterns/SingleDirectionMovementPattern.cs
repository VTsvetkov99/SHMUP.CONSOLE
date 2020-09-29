using ConsoleG.Interfaces.Movement;
using System.Collections.Generic;

namespace SHMUP.App.Movement.Patterns
{
    public class SingleDirectionMovementPattern : IMovementPattern
    {
        private readonly IMovementController _moveControl;
        private readonly MoveDirections _direction;

        public SingleDirectionMovementPattern(IMovementController moveControl, MoveDirections direction)
        {
            _moveControl = moveControl;
            _direction = direction;
        }

        public void Execute(IMovable movable)
        {
            int moves = 0;
            List<MoveCommand> commands = new List<MoveCommand>();

            switch (_direction)
            {
                case MoveDirections.Up:
                    moves = _moveControl.Map.Height - (_moveControl.Map.Height - movable.Position.X);
                    break;
                case MoveDirections.Down:
                    moves = _moveControl.Map.Height - (movable.Position.X + movable.Shape.Height);
                    break;
                case MoveDirections.Left:
                    moves = _moveControl.Map.Width - movable.Position.Y;
                    break;
                case MoveDirections.Right:
                    moves = _moveControl.Map.Width - (movable.Position.X + movable.Shape.Width);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < moves; i++)
                commands.Add(new MoveCommand(_direction, i, 1));

            lock (this)
            {
                foreach (var command in commands)
                    _moveControl.MoveAfter(movable, command);
            }
        }
    }
}
