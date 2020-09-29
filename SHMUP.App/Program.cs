using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Annimations;
using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using ConsoleG.Interfaces.Maps;
using ConsoleG.Interfaces.Movement;
using SHMUP.App.Assets;
using SHMUP.App.Graphics;
using SHMUP.App.Graphics.Annimations;
using SHMUP.App.Graphics.Shapes;
using SHMUP.App.Maps;
using SHMUP.App.Movement;
using SHMUP.App.Movement.Patterns;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace SHMUP.App
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource souce = new CancellationTokenSource();
            IGraphicsContext gc = new GraphicsContext();
            IGridMap map = new GridMap(gc);
            IMovementController aiMovement = new MovementController(souce.Token, map, 100);
            IMovementController playerMovement = new MovementController(souce.Token, map, 10);
            IMovementController projectileMovement = new MovementController(souce.Token, map, 20);

            IShape enemyShape = new EnemySpaceShipShape();
            IShape playerShape = new PlayerSpaceShipShape();

            IAnnimation destructionAnnimation = new ExplosionDestructionAnnimation();

            Point playerSpawn = new Point(map.Height - playerShape.Height, (map.Width - playerShape.Width) / 2);
            ISpaceShip player = new PlayerSpaceShip(playerSpawn, playerShape, destructionAnnimation);
            map.TryPlace(player);

            IMovementPattern rightLeftDown = new RightDownLeftMovementPattern(3, 2, 5, 100, aiMovement);
            IMovementPattern playerProjectileMovement = new SingleDirectionMovementPattern(projectileMovement, MoveDirections.Up);

            Task.Run(() => SpawnEnemies(map, enemyShape, destructionAnnimation, rightLeftDown));

            ReadControls(playerMovement, player, map, playerProjectileMovement);
        }

        private static void SpawnEnemies(IGridMap map, IShape enemyShape, IAnnimation destructionAnnimation, IMovementPattern rightLeftDown)
        {
            while(true)
            {
                ISpaceShip enemy1 = new EnemySpaceShip(new Point(1, 1), enemyShape, destructionAnnimation);
                ISpaceShip enemy2 = new EnemySpaceShip(new Point(1, 21), enemyShape, destructionAnnimation);
                ISpaceShip enemy3 = new EnemySpaceShip(new Point(1, 41), enemyShape, destructionAnnimation);

                map.TryPlace(enemy1);
                map.TryPlace(enemy2);
                map.TryPlace(enemy3);

                rightLeftDown.Execute(enemy1);
                rightLeftDown.Execute(enemy2);
                rightLeftDown.Execute(enemy3);

                Thread.Sleep(20000);
            }     
        }

        private static void ReadControls(
            IMovementController playerMovement,
            ISpaceShip player,
            IGridMap map,
            IMovementPattern shootPattern)
        {
            bool canShoot = true;

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        playerMovement.MoveAfter(player, new MoveCommand(MoveDirections.Up, 0, 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        playerMovement.MoveAfter(player, new MoveCommand(MoveDirections.Left, 0, 1));
                        break;
                    case ConsoleKey.RightArrow:
                        playerMovement.MoveAfter(player, new MoveCommand(MoveDirections.Right, 0, 1));
                        break;
                    case ConsoleKey.DownArrow:
                        playerMovement.MoveAfter(player, new MoveCommand(MoveDirections.Down, 0, 1));
                        break;
                    case ConsoleKey.Spacebar:

                        if (!canShoot)
                            continue;

                        var projectile = player.Projectile;
                        map.TryPlace(projectile);
                        shootPattern.Execute(projectile);
                        canShoot = false;
                        Task.Run(() => { Thread.Sleep(250); canShoot = true; });

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
