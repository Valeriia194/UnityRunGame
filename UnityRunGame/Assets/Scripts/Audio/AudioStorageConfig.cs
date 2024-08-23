using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [CreateAssetMenu(fileName = "AudioStorageConfig", menuName = "MyGame/AudioStorageConfig")]
    public class AudioStorageConfig : ScriptableObject
    {
        [SerializeField] private AudioClip[] clips;

        public bool TryGetClip(string key, out AudioClip audioClip)
        {
            audioClip = default;

            foreach (var clip in clips) 
            { 
                if (clip.name == key)
                {
                    audioClip = clip;
                    return true;
                }
            }

            return false;
        } 
    }
}
