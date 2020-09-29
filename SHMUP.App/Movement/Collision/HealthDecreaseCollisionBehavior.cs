using ConsoleG.Interfaces.Movement;
using System;

namespace SHMUP.App.Movement.Collision
{
    abstract class HealthDecreaseCollisionBehavior : ICollisionBehavior
    {
        private int _health;
        private readonly Action _destroyAction;
        protected abstract bool HasCollisionWith(ICollidable otherColidable);

        public HealthDecreaseCollisionBehavior(Action destroyAction, int initialHealth)
        {
            _health = initialHealth;
            _destroyAction = destroyAction;
        }

        public bool Collide(ICollidable otherCollidable)
        {
            if (HasCollisionWith(otherCollidable))
            {
                if (_health > 0)
                    _health--;
                else
                {
                    _destroyAction();
                    return false;
                }
            }

            return true;
        }
    }
}
