using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using ConsoleG.Interfaces.Movement;
using System;
using System.Drawing;

namespace SHMUP.App.Assets
{
    public abstract class SpaceShip : ISpaceShip
    {
        public event DestroyedEventHandler Destroyed;
        public Point Position { get; protected set; }
        public IShape Shape { get; }
        public DrawStates State { get; protected set; } = DrawStates.Created;
        public IAnnimation DestructionAnnimation { get; }

        public abstract IProjectile Projectile { get; }
        public abstract ICollisionBehavior CollideBehavior { get; }

        public SpaceShip(Point origin, IShape shape, IAnnimation destructionAnimation)
        {
            DestructionAnnimation = destructionAnimation;
            Position = origin;
            Shape = shape;
        }

        public virtual void Destroy()
        {
            if (State != DrawStates.Deleted)
            {
                State = DrawStates.Deleted;

                Destroyed?.Invoke();
            }
        }

        public void MoveTo(Point point)
        {
            if (State != DrawStates.Created)
                throw new InvalidOperationException("Cannot move object which is not in the CREATED state!");

            this.Position = point;
        }

        public void Shoot(IProjectile projectile)
        {
            throw new NotImplementedException();
        }
    }
}
