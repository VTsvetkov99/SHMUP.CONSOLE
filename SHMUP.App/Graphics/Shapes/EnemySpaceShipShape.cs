using ConsoleG.Interfaces.Graphics.Shapes;
using SHMUP.App.Graphics.Textures;
using System.Drawing;

namespace SHMUP.App.Graphics.Shapes
{
    public class EnemySpaceShipShape : IShape
    {
        public EnemySpaceShipShape()
        {
            Texture = new EnemyTexture();
        }
        public ITexture Texture { get; }

        public IShapeNode[] Nodes => new IShapeNode[] {
            new ShapeNode(new Point(0, 0)),
            new ShapeNode(new Point(0, 1)),
            new ShapeNode(new Point(0, 2)),
            new ShapeNode(new Point(0, 3)),
            new ShapeNode(new Point(0, 4)),
            new ShapeNode(new Point(1, 0)),
            new ShapeNode(new Point(1, 2)),
            new ShapeNode(new Point(1, 4)),
            new ShapeNode(new Point(2, 2)),
            new ShapeNode(new Point(3, 2))
        };
    }
}
