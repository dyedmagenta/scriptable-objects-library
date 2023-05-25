using System;
using SOLib.Variables;

namespace SOLib.References
{
    [Serializable]
    public class StringReference
    {
        public bool useConstant = true;
        public string constantValue;
        public StringVariable variable;

        public StringReference()
        {
        }

        public StringReference(string value)
        {
            useConstant = true;
            constantValue = value;
        }

        public string Value => useConstant ? constantValue : variable.Value;

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}