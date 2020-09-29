using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Textures
{
    public class LaserTexture : ITexture
    {
        public Color Color => Color.Cyan;

        public int PatternASCII => 179;
    }
}
