using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace ConsoleG.Interfaces.Graphics.Drawing
{
    public interface IDrawable
    {
        IShape Shape { get; }
        DrawStates State { get; }
        Point Position { get; }
    }

    public enum DrawStates
    {
        Created, Drawn, Deleted
    }
}
