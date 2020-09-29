using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Textures
{
    public class PlayerTexture : ITexture
    {
        public Color Color => Color.Yellow;

        public int PatternASCII => 9608;
    }
}
