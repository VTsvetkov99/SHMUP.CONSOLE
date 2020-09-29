using ConsoleG.Interfaces.Assets;
using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Maps;
using ConsoleG.Interfaces.Movement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SHMUP.App.Maps
{
    public class GridMap : IGridMap
    {
        private readonly IGraphicsContext _context;
        private readonly IDrawable[,] _map;
        private readonly IList<ICollidable> _collidables;

        public int Height => _map.GetLength(0);
        public int Width => _map.GetLength(1);

        public GridMap(IGraphicsContext context)
        {
            _context = context;
            _map = new IDrawable[_context.Scene.Height, _context.Scene.Witdth];
            _collidables = new List<ICollidable>();
        }

        public bool TryMove(IMovable movable, MoveDirections direction, int distance)
        {
            Point toMoveTo = GetPointToMoveTo(movable.Position, direction, distance);

            bool canMove = GetIsInBounds(movable, toMoveTo) && GetDoesNotViolateCollisions(movable, toMoveTo);

            if (canMove)
            {
                try
                {
                    _context.Drawable.Clear(movable);
                    movable.MoveTo(toMoveTo);
                    _context.Drawable.Draw(movable);
                }
                catch
                {
                    return false;
                }
            }

            return canMove;
        }

        public bool TryMoveMany(IEnumerable<IMovable> movables, MoveDirections direction, int distance)
        {
            throw new System.NotImplementedException();
        }

        public bool TryPlace(IDrawable drawable)
        {
            bool canPlace = GetIsInBounds(drawable);

            if (drawable is ICollidable collidable)
            {
                canPlace = GetDoesNotViolateCollisions(collidable, drawable.Position);

                if (canPlace)
                    _collidables.Add(collidable);
            }

            if (drawable is IDestructable destructable)
                destructable.Destroyed += () => HandleDestroyed(destructable);

            if (canPlace)
                _context.Drawable.Draw(drawable);

            return canPlace;
        }

        public bool TryPlaceMany(IEnumerable<IDrawable> movables)
        {
            throw new System.NotImplementedException();
        }

        private Point GetPointToMoveTo(Point current, MoveDirections direction, int distance)
        {
            return direction switch
            {
                MoveDirections.Up => new Point(current.X - distance, current.Y),
                MoveDirections.Down => new Point(current.X + distance, current.Y),
                MoveDirections.Left => new Point(current.X, current.Y - distance),
                MoveDirections.Right => new Point(current.X, current.Y + distance),
                _ => throw new NotSupportedException($"{direction} is not a supported moving direction"),
            };
        }

        private void HandleDestroyed(IDestructable destructable)
        {
            if (destructable is ICollidable collidable)
                _collidables.Remove(collidable);

            _context.Drawable.Clear(destructable);
            Point drawnOn = new Point(destructable.Shape.Height / 2 + destructable.Position.X, destructable.Shape.Width / 2 + destructable.Position.Y);
            _context.Drawable.Draw(destructable.DestructionAnnimation, drawnOn);
        }

        private bool GetIsInBounds(IDrawable moving, Point position = default)
        {
            if (position == default)
                position = moving.Position;

            bool exceedsHeight = moving.Shape.Height + position.X > Height || position.X < 1;
            bool exceedsWidth = moving.Shape.Width + position.Y > Width || position.Y < 1;
            bool outOfBounds = exceedsHeight || exceedsWidth;

            if (outOfBounds && !(moving is IPlayer))
            {
                _context.Drawable.Clear(moving);

                if (moving is ICollidable collidable)
                    _collidables.Remove(collidable);
            }

            return !outOfBounds;
        }

        private bool GetDoesNotViolateCollisions(IDrawable drawable, Point toMoveTo)
        {
            bool collides = false;

            if (drawable is ICollidable moving)
            {
                lock (_collidables)
                {
                    var otherCollidable = _collidables.Where(e => e != moving) // * Not this collidable
                        .FirstOrDefault(existing => existing.Shape.Nodes       // * The first where any of the nodes
                        .Any(existingNode => moving.Shape.Nodes                // * Collides with any of the nodes
                            .Any(movingNode =>                                 // * Of an existing collidable
                                 existing.Position.X + existingNode.Position.X == movingNode.Position.X + toMoveTo.X &&
                                 existing.Position.Y + existingNode.Position.Y == movingNode.Position.Y + toMoveTo.Y
                                )
                            )
                        );

                    if (otherCollidable != null)
                    {
                        collides = !moving.CollideBehavior.Collide(otherCollidable);
                        otherCollidable.CollideBehavior.Collide(moving);
                    }
                }
            }

            return !collides;
        }
    }
}
