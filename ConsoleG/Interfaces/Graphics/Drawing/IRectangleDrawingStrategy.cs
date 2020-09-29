using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace ConsoleG.Interfaces.Graphics.Drawing
{
    public interface IRectangleDrawingStrategy
    {
        void Draw(Point a, Point b, ITexture texture);
    }
}
