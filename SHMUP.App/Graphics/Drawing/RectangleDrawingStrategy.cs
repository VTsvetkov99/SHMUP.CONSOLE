using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SHMUP.App.Graphics.Drawing
{
    public class RectangleDrawingStrategy : IRectangleDrawingStrategy
    {
        private readonly IScene _scene;

        public RectangleDrawingStrategy(IScene scene)
        {
            _scene = scene;
        }

        public void Draw(Point a, Point b, ITexture texture)
        {
            _scene.ValidatePoint(a);
            _scene.ValidatePoint(b);

            IEnumerable<Point> toColor = GetPointsToColor(a, b);

            foreach (Point point in toColor)
                _scene.DrawPoint(point, texture);
        }

        private IEnumerable<Point> GetPointsToColor(Point start, Point target)
        {
            List<Point> result = new List<Point>();
            Point cursor = new Point(start.X, start.Y);

            int xIncrement;
            int yIncrement;

            do
            {
                cursor.Y = start.Y;

                do
                {
                    result.Add(new Point(cursor.X, cursor.Y));

                    yIncrement = Math.Sign(cursor.Y - target.Y);
                    cursor.Y -= yIncrement;
                }
                while (yIncrement != 0);

                xIncrement = Math.Sign(cursor.X - target.X);
                cursor.X -= xIncrement;
            }
            while (xIncrement != 0);

            return result;
        }
    }
}
