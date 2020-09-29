using ConsoleG.Interfaces.Graphics.Annimations;
using System.Drawing;

namespace ConsoleG.Interfaces.Graphics.Drawing
{
    public interface IDrawableDrawingStrategy
    {
        void Draw(IDrawable shape);
        void Clear(IDrawable movable);
        void Draw(IAnnimation annimation, Point point);
    }
}
