using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Audio
{
    public class AudioInstance : MonoBehaviour
    {
        [SerializeField] AudioSource Source;

        private ObjectPool pool;
        public void SetPool (ObjectPool pool)
        {
            this.pool = pool;
        }
        public void Play(AudioClip clip, AudioSettings settings)
        {
            Source.clip = clip;
            Source.Play();

            if(!Source.loop)
            {
                StartCoroutine(DisableOnComplete());
            }
        }

        private IEnumerator DisableOnComplete()
        {
            yield return new WaitForSeconds(Source.clip.length);
        }
    }
}
