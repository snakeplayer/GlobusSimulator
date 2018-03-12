/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPT-I, Geneva
 * Date : 12.3.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : HumanType.cs
 * Class desc. :
 */
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
