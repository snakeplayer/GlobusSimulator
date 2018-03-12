/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPT-I, Geneva
 * Date : 12.3.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : MediumHumanType.cs
 * Class desc. : Represent a medium human
 */
using System.Drawing;

namespace GlobusSimulator
{
    public class MediumHumanType : HumanType
    {
        private static MediumHumanType _uniqueInstance;

        protected MediumHumanType() : base(Color.Orange, 100)
        {
            // no code
        }

        public static MediumHumanType CreateInstance()
        {
            _uniqueInstance = _uniqueInstance ?? new MediumHumanType();
            return _uniqueInstance;
        }
    }
}
