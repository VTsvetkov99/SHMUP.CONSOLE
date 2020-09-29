using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Shapes;
using ConsoleG.Interfaces.Movement;
using SHMUP.App.Graphics.Annimations;
using SHMUP.App.Graphics.Shapes;
using SHMUP.App.Movement.Collision;
using System.Drawing;

namespace SHMUP.App.Assets
{
    public class PlayerSpaceShip : SpaceShip, IPlayer
    {
        public PlayerSpaceShip(Point origin, IShape shape, IAnnimation destructionAnimation)
            : base(origin, shape, destructionAnimation)
        {
            CollideBehavior = new PlayerSpaceShipCollisionBehavior(Destroy);
        }

        public override IProjectile Projectile => new Laser(this, new Point(Position.X - 1, Position.Y + Shape.Width / 2));
        public override ICollisionBehavior CollideBehavior { get; }

        public class Laser : Projectile
        {
            public Laser(ISpaceShip spaceShip, Point origin)
                : base(spaceShip, new LaserShape(), new ExplosionDestructionAnnimation(), origin)
            {
            }
        }
    }
}
