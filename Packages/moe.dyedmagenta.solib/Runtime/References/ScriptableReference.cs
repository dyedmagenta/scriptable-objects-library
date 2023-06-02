using System;
using SOLib.Variables;

namespace SOLib.References
{
    [Serializable]
    public abstract class ScriptableReference<T>
    {
        public bool useConstant = true;
        public T constantValue;
        public ScriptableVariable<T> variable;

        protected ScriptableReference()
        {
        }

        protected ScriptableReference(T value)
        {
            useConstant = true;
            constantValue = value;
        }

        public T Value => useConstant ? constantValue : variable.Value;

        public static implicit operator T(ScriptableReference<T> reference)
        {
            return reference.Value;
        }
    }
}