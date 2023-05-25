using System;
using SOLib.Variables;
using UnityEngine;

namespace SOLib.References
{
    [Serializable]
    public class AudioClipReference
    {
        public bool useConstant = true;
        public AudioClip constantValue;
        public AudioClipVariable variable;

        public AudioClipReference()
        {
        }

        public AudioClipReference(AudioClip value)
        {
            useConstant = true;
            constantValue = value;
        }

        public AudioClip Value => useConstant ? constantValue : variable.Value;

        public static implicit operator AudioClip(AudioClipReference reference)
        {
            return reference.Value;
        }
    }
}