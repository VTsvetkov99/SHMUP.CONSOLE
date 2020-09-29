using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Drawing;

namespace ConsoleG.Interfaces.Movement
{
    public interface IDestructable : IDrawable
    {
        event DestroyedEventHandler Destroyed;
        void Destroy();
        IAnnimation DestructionAnnimation { get; }
    }

    public delegate void DestroyedEventHandler();
}
