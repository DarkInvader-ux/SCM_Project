using System;
using UnityEngine;

namespace _PROJECT.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource audioSource;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetAudio(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            if (audioClip != null)
            {
                audioSource.Play();
            }
        }
        
    }
}
