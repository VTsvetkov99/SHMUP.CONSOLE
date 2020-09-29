using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement.Collision
{
    abstract class InstantDestoryCollisionBehavior : ICollisionBehavior
    {
        private readonly Action _destroyAction;
        protected abstract bool HasCollisionWith(ICollidable otherColidable);

        public InstantDestoryCollisionBehavior(Action destroyAction)
        {
            _destroyAction = destroyAction;
        }

        public bool Collide(ICollidable otherCollidable)
        {
            if (HasCollisionWith(otherCollidable))
            {
                _destroyAction();
                return false;
            }

            return true;
        }
    }
}
