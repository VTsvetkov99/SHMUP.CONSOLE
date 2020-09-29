using ConsoleG.Interfaces.Graphics.Shapes;
using SHMUP.App.Graphics.Textures;
using System.Drawing;

namespace SHMUP.App.Graphics.Shapes
{
    public class LaserShape : IShape
    {
        public ITexture Texture => new LaserTexture();

        public IShapeNode[] Nodes => new IShapeNode[] {
            new ShapeNode(new Point(0, 0)),
        };
}
}
