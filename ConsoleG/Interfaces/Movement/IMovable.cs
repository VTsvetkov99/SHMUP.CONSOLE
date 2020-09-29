using ConsoleG.Interfaces.Graphics.Drawing;
using System.Drawing;

namespace ConsoleG.Interfaces.Movement
{
    public interface IMovable : IDrawable
    {
        void MoveTo(Point point);
    }

    public enum MoveDirections
    {
        Up, Down, Left, Right
    }
}
