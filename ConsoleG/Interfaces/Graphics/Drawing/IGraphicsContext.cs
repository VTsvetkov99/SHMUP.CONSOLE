namespace ConsoleG.Interfaces.Graphics.Drawing
{
    public interface IGraphicsContext
    {
        IScene Scene { get; }
        IDrawableDrawingStrategy Drawable { get; }
        ILineDrawingStrategy Line { get; }
        IRectangleDrawingStrategy Rectangle { get; }
    }
}
