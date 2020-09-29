using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Graphics.Shapes;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace SHMUP.App.Graphics
{
    public class Scene : IScene
    {
        private readonly int _sceneMinWidth = 61;
        private readonly int _sceneMaxHeight = 31;

        public int Witdth { get; }
        public int Height { get; }

        public Scene(int screenWidth = 0, int screenHeight = 0)
        {
            Console.BackgroundColor = Color.Black;
            Console.CursorVisible = false;
            Console.Clear();

            Witdth = Math.Max(_sceneMinWidth, screenWidth);
            Height = Math.Max(_sceneMaxHeight, screenHeight);

            AdjustScreenDimentions();
        }

        public void DrawPoint(Point point, ITexture texture)
        {
            ValidatePoint(point);

            Console.SetCursorPosition(point.Y, point.X);
            Console.Write((char)texture.PatternASCII, texture.Color);
        }

        public void ValidatePoint(Point a)
        {
            if (a.Y > _sceneMinWidth || a.X > _sceneMaxHeight || a.X < 0 || a.Y < 0)
                throw new ArgumentOutOfRangeException($"The point with coordinates ({a.X}, {a.Y}) was outside the bounds of the scene ({_sceneMaxHeight}, {_sceneMinWidth})");
        }

        public void AdjustScreenDimentions()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            Console.WindowHeight = _sceneMaxHeight;
            Console.WindowWidth = _sceneMinWidth;

            Console.BufferHeight = _sceneMaxHeight;
            Console.BufferWidth = _sceneMinWidth;
        }
    }
}
