using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement.Collision
{
    class PlayerSpaceShipCollisionBehavior : InstantDestoryCollisionBehavior
    {
        public PlayerSpaceShipCollisionBehavior(Action destroyAction) 
            : base(destroyAction)
        {
        }

        protected override bool HasCollisionWith(ICollidable otherColidable)
        {
            return otherColidable is IEnemy;
        }
    }
}
