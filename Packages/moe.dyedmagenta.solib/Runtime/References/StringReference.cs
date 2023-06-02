using System;

namespace SOLib.References
{
    [Serializable]
    public class StringReference : ScriptableReference<string>
    {
        public StringReference()
        {
        }

        public StringReference(string value) : base(value)
        {
        }
    }
}