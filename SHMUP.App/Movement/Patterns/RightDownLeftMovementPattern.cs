using ConsoleG.Interfaces.Movement;
using System.Collections.Generic;

namespace SHMUP.App.Movement.Patterns
{
    public class RightDownLeftMovementPattern : IMovementPattern
    {
        private readonly int _hInterval;
        private readonly int _vInterval;
        private readonly IMovementController _moveControl;
        private readonly int _iterations;
        private readonly int _tInterval;

        public RightDownLeftMovementPattern(int iterations, int hInterval, int vInterval, int tInterval, IMovementController moveControl)
        {
            _hInterval = hInterval;
            _vInterval = vInterval;
            _moveControl = moveControl;
            _iterations = iterations;
            _tInterval = tInterval;
        }

        public void Execute(IMovable movable)
        {

            int moveOffset = 0;
            List<IMoveCommand> toExecute = new List<IMoveCommand>();
            int currentY = movable.Position.Y;
            int currentX = movable.Position.X;

            for (int i = 0; i < _iterations; i++)
            {
                int rightMoves = MoveRight(movable, ref moveOffset, toExecute, currentY);

                MoveDown(movable, ref moveOffset, toExecute, ref currentX);

                int leftMoves = MoveLeft(ref moveOffset, toExecute, currentY, rightMoves);

                MoveDown(movable, ref moveOffset, toExecute, ref currentX);

                currentY = currentY + rightMoves * _hInterval - leftMoves * _hInterval;
            }

            foreach (IMoveCommand command in toExecute)
                _moveControl.MoveAfter(movable, command);
        }

        private int MoveRight(IMovable movable, ref int moveOffset, List<IMoveCommand> toExecute, int currentY)
        {
            int rightMoves = (_moveControl.Map.Width - (currentY + movable.Shape.Width)) / _hInterval;

            for (int j = 0; j < rightMoves; j++)
            {
                toExecute.Add(new MoveCommand(MoveDirections.Right, moveOffset, _hInterval));
                moveOffset += _tInterval;
            }

            return rightMoves;
        }

        private int MoveLeft(ref int moveOffset, List<IMoveCommand> toExecute, int currentY, int rightMoves)
        {
            int leftMoves = rightMoves + currentY / _hInterval;

            for (int j = leftMoves; j > 0; j--)
            {
                toExecute.Add(new MoveCommand(MoveDirections.Left, moveOffset, _hInterval));
                moveOffset += _tInterval;
            }

            return leftMoves;
        }

        private void MoveDown(IMovable movable, ref int moveOffset, List<IMoveCommand> toExecute, ref int currentX)
        {
            toExecute.Add(new MoveCommand(MoveDirections.Down, moveOffset, _vInterval));
            currentX += _vInterval;
            moveOffset += _tInterval;
        }
    }
}
