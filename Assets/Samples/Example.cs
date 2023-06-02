using SOLib.References;
using UnityEngine;

namespace Samples
{
    public class Example : MonoBehaviour
    {
        public FloatReference floatReference;
        public BooleanReference booleanReference;
        
        public void Start()
        {
            floatReference = new FloatReference(12f);
        }

        public void PrintValue()
        {
            Debug.Log(floatReference.Value + " " + booleanReference.Value);
        }
    }
}