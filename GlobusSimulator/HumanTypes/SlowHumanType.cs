/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPT-I, Geneva
 * Date : 12.3.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : SlowHumanType.cs
 * Class desc. : Represent a slow human
 */
using System.Drawing;

namespace GlobusSimulator
{
    public class SlowHumanType : HumanType
    {
        private static SlowHumanType _uniqueInstance;

        protected SlowHumanType() : base(Color.Yellow, 150)
        {
            // no code
        }

        public static SlowHumanType CreateInstance()
        {
            _uniqueInstance = _uniqueInstance ?? new SlowHumanType();
            return _uniqueInstance;
        }
    }
}
