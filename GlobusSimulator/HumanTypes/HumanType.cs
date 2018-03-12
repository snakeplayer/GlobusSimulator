using System.Drawing;

namespace GlobusSimulator
{
    public abstract class HumanType
    {
        public Color Color { get; }
        public int Speed { get; }

        protected HumanType(Color color, int speed)
        {
            this.Color = color;
            this.Speed = speed;
        }
    }
}
