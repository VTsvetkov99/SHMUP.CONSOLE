using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace ConsoleG.Interfaces.Graphics.Drawing
{
    public interface IScene
    {
        int Witdth { get; }
        int Height { get; }
        void DrawPoint(Point point, ITexture texture);
        void ValidatePoint(Point point);
    }
}
