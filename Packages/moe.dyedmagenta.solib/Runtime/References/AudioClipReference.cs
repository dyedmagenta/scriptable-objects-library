using System;
using UnityEngine;

namespace SOLib.References
{
    [Serializable]
    public class AudioClipReference : ScriptableReference<AudioClip>
    {
        public AudioClipReference()
        {
        }

        public AudioClipReference(AudioClip value) : base(value)
        {
        }
    }
}