using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Project;
using UnityEngine.Pool;

namespace Assets.Scripts.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioStorageConfig config;
        [SerializeField] private AudioInstance sfxPrefab;
        [SerializeField] private AudioInstance musicPrefab;
        private ObjectPool sfxPool;
        
        private void Awake()
        {
            sfxPool = new ObjectPool(sfxPrefab.gameObject);
            DontDestroyOnLoad(this);
        }

        public void Start()
        {
            var audioService = ProjectContext.Instance.AudioService;
            audioService.OnMusic += AudioServiceOnMusic;
            audioService.OnSfx += AudioServiceOnSfx;
        }

        private void AudioServiceOnSfx(AudioSettings settings)
        {
            //var instance = sfxPool.Pool.Get().GetComponent<AudioInstance>();    

            var instance = sfxPool.Get().GetComponent<AudioInstance>();
            instance.SetPool(sfxPool);
            if (config.TryGetClip(settings.SoundKey, out AudioClip clip))
            {
                instance.gameObject.SetActive(true);
                instance.Play(clip, settings);
            }
            else
            {
                Debug.LogAssertion($"There is no key with name {settings.SoundKey}");
            }
        }

        private void AudioServiceOnMusic(AudioSettings obj)
        {

        }
    }
}
