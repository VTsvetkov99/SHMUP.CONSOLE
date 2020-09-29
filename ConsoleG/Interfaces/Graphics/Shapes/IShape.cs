using System.Linq;

namespace ConsoleG.Interfaces.Graphics.Shapes
{
    public interface IShape
    {
        int Width => Nodes.Select(n => n.Position.Y).Max() + 1;
        int Height => Nodes.Select(n => n.Position.X).Max() + 1;
        ITexture Texture { get; }
        IShapeNode[] Nodes { get; }
    }
}
