using ConsoleG.Interfaces.Graphics.Drawing;
using SHMUP.App.Graphics.Drawing;

namespace SHMUP.App.Graphics
{
    /// <summary>
    /// Responsible for configuring the drawing strategies for the Scene
    /// </summary>
    public class GraphicsContext : IGraphicsContext
    {
        /// <summary>
        /// Creates a Graphics Context with the default console strategies
        /// </summary>
        /// <param name="width">Height of the conole window</param>
        /// <param name="height">Width of the conole window</param>
        public GraphicsContext(int width = 0, int height = 0)
        {
            this.Scene = new Scene(width, height);
            this.Line = new LineDrawingStrategy(Scene);
            this.Rectangle = new RectangleDrawingStrategy(Scene);
            this.Drawable = new DrawableDrawingStrategy(Scene);
        }

        public IScene Scene { get; }
        public ILineDrawingStrategy Line { get; }
        public IRectangleDrawingStrategy Rectangle { get; }
        public IDrawableDrawingStrategy Drawable { get; }
    }
}
