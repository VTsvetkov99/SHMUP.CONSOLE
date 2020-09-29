using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Shapes
{
    class ExplosionTexture : ITexture
    {
        public Color Color => Color.Orange;

        public int PatternASCII => 42;
    }
}
