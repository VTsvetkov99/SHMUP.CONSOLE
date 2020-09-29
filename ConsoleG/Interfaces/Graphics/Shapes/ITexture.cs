using System.Drawing;

namespace ConsoleG.Interfaces.Graphics.Shapes
{
    public interface ITexture
    {
        Color Color { get; }
        int PatternASCII { get; }
    }
}
