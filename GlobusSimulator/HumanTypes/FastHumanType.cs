/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPT-I, Geneva
 * Date : 12.3.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : FastHumanType.cs
 * Class desc. : Represent a fast human
 */
using System.Drawing;

namespace GlobusSimulator
{
    public class FastHumanType : HumanType
    {
        private static FastHumanType _uniqueInstance;

        protected FastHumanType() : base(Color.Red, 50)
        {
            // no code
        }

        public static FastHumanType CreateInstance()
        {
            _uniqueInstance = _uniqueInstance ?? new FastHumanType();
            return _uniqueInstance;
        }
    }
}
