using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement.Collision
{
    class LaserProjectileCollisionBehavior : InstantDestoryCollisionBehavior
    {
        public LaserProjectileCollisionBehavior(Action destroyAction)
            : base(destroyAction)
        {
        }

        protected override bool HasCollisionWith(ICollidable otherColidable)
        {
            return otherColidable is IEnemy;
        }
    }
}
