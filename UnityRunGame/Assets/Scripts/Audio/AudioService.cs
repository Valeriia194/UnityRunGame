using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Audio
{
    public interface IAudioService
    {
        void PlayMusic(AudioSettings settings);
        void PlayeSfx(AudioSettings settings);

        event Action<AudioSettings> OnMusic;
        event Action<AudioSettings> OnSfx;
        float VolumeMusic { get; set; }
        float Volume { get; set; }
    }
    public class AudioService : IAudioService
    {
        public float VolumeMusic { get; set; }
        public float Volume { get; set; }

        public event Action<AudioSettings> OnMusic;
        public event Action<AudioSettings> OnSfx;

        public void PlayeSfx(AudioSettings settings)
        {
            OnSfx?.Invoke(settings);
        }

        public void PlayMusic(AudioSettings settings)
        {
            OnMusic?.Invoke(settings);
        }
    }

    public struct AudioSettings
    {
        public string SoundKey;
        public float Volume;
        public bool IsOnCamera;
        public Vector3 Position;

        public AudioSettings(string soundKey)
        {
            SoundKey = soundKey;
            Volume = 1.0f;
            IsOnCamera = false;
            Position = Vector3.zero;
        }
    }
}