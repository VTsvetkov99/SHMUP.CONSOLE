using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using ConsoleG.Interfaces.Movement;
using SHMUP.App.Movement.Collision;
using System;
using System.Drawing;

namespace SHMUP.App.Assets
{
    public abstract class Projectile : IProjectile
    {

        public event DestroyedEventHandler Destroyed;
        public IAnnimation DestructionAnnimation { get; }
        public IShape Shape { get; }
        public DrawStates State { get; private set; } = DrawStates.Created;
        public Point Position { get; private set; }
        public ISpaceShip Source { get; }
        public ICollisionBehavior CollideBehavior { get; }
        public Projectile(ISpaceShip spaceShip, IShape shape, IAnnimation annimation, Point position)
        {
            Source = spaceShip;
            Shape = shape;
            DestructionAnnimation = annimation;
            Position = position;
            CollideBehavior = new LaserProjectileCollisionBehavior(Destroy);
        }

        public void Destroy()
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
    }
}
