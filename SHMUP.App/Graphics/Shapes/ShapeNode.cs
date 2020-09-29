using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Shapes
{
    public class ShapeNode : IShapeNode
    {
        public ShapeNode(Point coordinates)
        {
            Position = coordinates;
        }

        public Point Position { get; }
    }
}
