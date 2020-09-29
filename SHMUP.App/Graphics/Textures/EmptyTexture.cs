using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Textures
{
    public class EmptyTexture : ITexture
    {
        public Color Color => Color.Black;

        public int PatternASCII => 9608;
    }
}
