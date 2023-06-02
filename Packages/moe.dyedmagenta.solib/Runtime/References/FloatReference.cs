using System;

namespace SOLib.References
{
    [Serializable]
    public class FloatReference : ScriptableReference<float>
    {
        public FloatReference()
        {
        }

        public FloatReference(float value) : base(value)
        {
        }
    }
}