using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Shapes;
using ConsoleG.Interfaces.Movement;
using SHMUP.App.Movement.Collision;
using System.Drawing;

namespace SHMUP.App.Assets
{
    public class EnemySpaceShip : SpaceShip, IEnemy
    {
        public EnemySpaceShip(Point origin, IShape shape, IAnnimation destructionAnimation)
            : base(origin, shape, destructionAnimation)
        {
            CollideBehavior = new EnemySpaceShipCollisionBehavior(Destroy, 3);
        }

        public override IProjectile Projectile => throw new System.NotImplementedException();

        public override ICollisionBehavior CollideBehavior { get; }
    }
}
