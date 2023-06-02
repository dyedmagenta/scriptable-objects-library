using UnityEngine;

namespace SOLib.Variables
{
    public class ScriptableVariable<T> : ScriptableObject
    {
        [SerializeField] protected bool initialize = true;
        [SerializeField] protected T initialValue;
        [SerializeField] protected T value;

        private void OnEnable()
        {
            if (initialize)
            {
                value = initialValue;
            }
        }

        public T Value
        {
            get => value;
            set => this.value = value;
        }
    }
}
