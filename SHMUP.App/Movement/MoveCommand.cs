using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement
{
    public class MoveCommand : IMoveCommand
    {
        public MoveCommand(MoveDirections direction, int delay, int distance)
        {
            Direction = direction;
            Delay = delay;
            Distance = distance;
        }

        public MoveDirections Direction { get; }

        public int Delay { get; private set; }

        public int Distance { get; }

        public void CountDown(int time)
        {
            Delay = Math.Max(0, Delay - time);
        }
    }
}
