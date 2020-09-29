using System;

namespace ConsoleG.Interfaces.Movement
{
    public interface ICollisionBehavior
    {
        bool Collide(ICollidable otherCollidable);
    }
}
