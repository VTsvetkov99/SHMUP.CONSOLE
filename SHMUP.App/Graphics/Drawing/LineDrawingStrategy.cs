using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SHMUP.App.Graphics.Drawing
{
    public class LineDrawingStrategy : ILineDrawingStrategy
    {
        private readonly IScene _scene;

        public LineDrawingStrategy(IScene context)
        {
            _scene = context;
        }

        public void Draw(Point a, Point b, ITexture texture)
        {
            _scene.ValidatePoint(a);
            _scene.ValidatePoint(b);

            ValidateLine(a, b);

            IEnumerable<Point> toColor = GetPointsToColor(a, b);

            foreach (Point point in toColor)
                _scene.DrawPoint(point, texture);
        }

        private void ValidateLine(Point a, Point b)
        {
            bool isHorizontal = a.Y == b.Y;
            bool isVertical = a.X == b.X;
            bool isDiagonal = Math.Abs(a.X - b.X) == Math.Abs(a.Y - b.Y);

            if (!isHorizontal && !isVertical && !isDiagonal)
                throw new InvalidOperationException($"Lines can only be horizontal, vertical or diagonal!");
        }

        private IEnumerable<Point> GetPointsToColor(Point start, Point target)
        {
            List<Point> result = new List<Point>();
            Point cursor = new Point(start.X, start.Y);

            int xIncrement;
            int yIncrement;

            do
            {
                result.Add(cursor);

                xIncrement = Math.Sign(cursor.X - target.X);
                yIncrement = Math.Sign(cursor.Y - target.Y);

                cursor.X -= xIncrement;
                cursor.Y -= yIncrement;

                cursor = new Point(cursor.X, cursor.Y);
            }
            while (xIncrement != 0 || yIncrement != 0);

            return result;
        }
    }
}
