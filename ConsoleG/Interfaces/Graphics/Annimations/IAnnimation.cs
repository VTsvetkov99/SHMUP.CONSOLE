using ConsoleG.Interfaces.Graphics.Shapes;
using System.Collections.Generic;

namespace ConsoleG.Interfaces.Graphics.Annimations
{
    public interface IAnnimation
    {
        IEnumerable<IShape> States { get; }
        int DellayBetweenFrames { get; }
    }
}
