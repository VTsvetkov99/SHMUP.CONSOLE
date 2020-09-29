using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement.Collision
{
    class EnemySpaceShipCollisionBehavior : HealthDecreaseCollisionBehavior
    {
        public EnemySpaceShipCollisionBehavior(Action destroyAction, int initialHealth)
            : base(destroyAction, initialHealth)
        {
        }

        protected override bool HasCollisionWith(ICollidable otherColidable)
        {
            return otherColidable is IProjectile projectile && projectile.Source is IPlayer;
        }
    }
}
