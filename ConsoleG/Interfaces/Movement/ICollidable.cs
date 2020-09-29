using ConsoleG.Interfaces.Graphics.Drawing;

namespace ConsoleG.Interfaces.Movement
{
    public interface ICollidable : IDrawable
    {
        ICollisionBehavior CollideBehavior { get; }
    }
}
