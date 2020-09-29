using ConsoleG.Interfaces.Graphics.Shapes;
using SHMUP.App.Graphics.Textures;
using System.Drawing;

namespace SHMUP.App.Graphics.Shapes
{
    public class PlayerSpaceShipShape : IShape
    {
        public PlayerSpaceShipShape()
        {
            Texture = new PlayerTexture();
        }

        public ITexture Texture { get; }

        public IShapeNode[] Nodes => new IShapeNode[] { 
            new ShapeNode(new Point(0, 2)), 
            new ShapeNode(new Point(1, 2)),
            new ShapeNode(new Point(1, 3)),
            new ShapeNode(new Point(1, 1)),
            new ShapeNode(new Point(2, 2)),
            new ShapeNode(new Point(2, 1)),
            new ShapeNode(new Point(2, 0)),
            new ShapeNode(new Point(2, 2)),
            new ShapeNode(new Point(2, 3)),
            new ShapeNode(new Point(2, 4)),
            new ShapeNode(new Point(3, 0)),
            new ShapeNode(new Point(3, 4))
        };
    }
}
