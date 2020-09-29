using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Shapes;
using SHMUP.App.Graphics.Shapes;
using System.Collections.Generic;
using System.Drawing;

namespace SHMUP.App.Graphics.Annimations
{
    public class ExplosionDestructionAnnimation : IAnnimation
    {
        public IEnumerable<IShape> States => new IShape[]
        {
            new Stage1(),
            new Stage2(),
            new Stage3(),
            new Stage1(),
        };

        public int DellayBetweenFrames => 100;

        private class Stage1 : IShape
        {
            ITexture IShape.Texture => new ExplosionTexture();
            public IShapeNode[] Nodes => new IShapeNode[] {
                new ShapeNode(new Point(2, 2))
            };
        }

        private class Stage2 : IShape
        {
            ITexture IShape.Texture => new ExplosionTexture();
            public IShapeNode[] Nodes => new IShapeNode[] {
                new ShapeNode(new Point(1, 2)),
                new ShapeNode(new Point(2, 2)),
                new ShapeNode(new Point(3, 2)),
                new ShapeNode(new Point(2, 1)),
                new ShapeNode(new Point(2, 3)),
            };
        }

        private class Stage3 : IShape
        {
            ITexture IShape.Texture => new ExplosionTexture();
            public IShapeNode[] Nodes => new IShapeNode[] {
                new ShapeNode(new Point(1, 2)),
                new ShapeNode(new Point(3, 2)),
                new ShapeNode(new Point(2, 1)),
                new ShapeNode(new Point(2, 3)),
                new ShapeNode(new Point(0, 3)),
                new ShapeNode(new Point(2, 3)),
                new ShapeNode(new Point(1, 2)),
                new ShapeNode(new Point(1, 4)),
            };
        }

        private class Stage4 : IShape
        {
            ITexture IShape.Texture => new ExplosionTexture();
            public IShapeNode[] Nodes => new IShapeNode[] {
                new ShapeNode(new Point(1, 2)),
                new ShapeNode(new Point(3, 2)),
                new ShapeNode(new Point(2, 1)),
                new ShapeNode(new Point(2, 3)),
            };
        }
    }
}
