using ConsoleG.Interfaces.Graphics.Shapes;
using System.Drawing;

namespace SHMUP.App.Graphics.Textures
{
    public class EnemyTexture : ITexture
    {
        public Color Color => Color.Red;

        public int PatternASCII => 9553;
    }
}
