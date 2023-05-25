using System;
using SOLib.Variables;

namespace SOLib.References
{
    [Serializable]
    public class BooleanReference : ScriptableReference<bool>
    {
        public BooleanReference()
        {
        }

        public BooleanReference(bool value) : base(value)
        {
        }
    }
}