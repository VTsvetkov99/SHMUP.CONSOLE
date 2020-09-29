using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using SHMUP.App.Graphics.Textures;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace SHMUP.App.Graphics.Drawing
{
    public class DrawableDrawingStrategy : IDrawableDrawingStrategy
    {
        private readonly IScene _scene;

        public DrawableDrawingStrategy(IScene scene)
        {
            _scene = scene;
        }

        public void Clear(IDrawable drawable)
        {
            var emptyTexture = new EmptyTexture();

            DrawNodes(drawable, emptyTexture);
        }

        public void Draw(IDrawable drawable)
        {
            ValidateInBoundery(drawable.Position, drawable);

            DrawNodes(drawable);
        }

        public void Draw(IAnnimation annimation, Point point)
        {
            var emptyTexture = new EmptyTexture();

            Task.Run(() =>
            {
                foreach (IShape shape in annimation.States)
                {
                    lock (_scene)
                    {
                        foreach (IShapeNode node in shape.Nodes)
                            _scene.DrawPoint(new Point(node.Position.X + point.X, node.Position.Y + point.Y), shape.Texture);
                    }

                    Thread.Sleep(annimation.DellayBetweenFrames);

                    lock (_scene)
                    {
                        foreach (IShapeNode node in shape.Nodes)
                            _scene.DrawPoint(new Point(node.Position.X + point.X, node.Position.Y + point.Y), emptyTexture);
                    }
                }
            });
        }

        private void ValidateInBoundery(Point point, IDrawable drawable)
        {
            Point furthest = new Point(point.X + drawable.Shape.Height, point.Y + drawable.Shape.Width);

            try
            {
                _scene.ValidatePoint(furthest);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"The furthest point of the given shape ({furthest.X},{furthest.Y}) is outside of the bounds of the map ({_scene.Height},{_scene.Witdth})");
            }
        }

        private void DrawNodes(IDrawable drawable, ITexture texture = default)
        {
            if (texture == default)
                texture = drawable.Shape.Texture;

            lock (_scene)
            {
                foreach (IShapeNode node in drawable.Shape.Nodes)
                    _scene.DrawPoint(new Point(node.Position.X + drawable.Position.X, node.Position.Y + drawable.Position.Y), texture);
            }
        }
    }
}
