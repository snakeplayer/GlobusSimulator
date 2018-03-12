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
