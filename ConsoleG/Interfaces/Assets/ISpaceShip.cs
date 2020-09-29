using ConsoleG.Interfaces.Movement;

namespace ConsoleG.Interfaces.Assets
{
    public interface ISpaceShip : IMovable, IDestructable, ICollidable
    {
        void Shoot(IProjectile projectile);
        IProjectile Projectile { get; }
    }
}
