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
