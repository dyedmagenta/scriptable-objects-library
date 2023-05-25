using System;
using SOLib.Variables;

namespace SOLib.References
{
    [Serializable]
    public class BooleanReference
    {
        public bool useConstant = true;
        public bool constantValue;
        public BooleanVariable variable;

        public BooleanReference()
        {
        }

        public BooleanReference(bool value)
        {
            useConstant = true;
            constantValue = value;
        }

        public bool Value => useConstant ? constantValue : variable.Value;

        public static implicit operator bool(BooleanReference reference)
        {
            return reference.Value;
        }
    }
}