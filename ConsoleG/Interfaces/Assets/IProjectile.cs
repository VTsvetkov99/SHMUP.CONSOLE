using ConsoleG.Interfaces.Movement;

namespace ConsoleG.Interfaces.Assets
{
    public interface IProjectile: IMovable, IDestructable, ICollidable
    {
        ISpaceShip Source { get; }
    }
}
