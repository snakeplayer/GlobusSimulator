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
