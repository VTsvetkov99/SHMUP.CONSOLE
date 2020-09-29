using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Movement;
using System.Collections.Generic;

namespace ConsoleG.Interfaces.Maps
{
    public interface IGridMap 
    {
        int Width { get; }
        int Height { get; }
        bool TryPlace(IDrawable drawable);
        bool TryPlaceMany(IEnumerable<IDrawable> drawables);
        bool TryMove(IMovable movable, MoveDirections direction, int distance);
        bool TryMoveMany(IEnumerable<IMovable> movables, MoveDirections direction, int distance);
    }
}
