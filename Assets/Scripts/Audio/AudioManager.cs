using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private AudioSource _audioSource;

        [SerializeField] private AudioClip coinAudio;
        [SerializeField] private AudioClip fruitAudio;
        [SerializeField] private AudioClip hurtAudio;
        [SerializeField] private AudioClip deathAudio;
        [SerializeField] private AudioClip jumpAudio;
        
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
            
            _audioSource = GetComponent<AudioSource>();
            
        }
        
        public void PlayCoinSound() => PlaySound(coinAudio);
        public void PlayFruitSound() => PlaySound(fruitAudio);
        public void PlayHurtSound()  => PlaySound(hurtAudio);
        public void PlayDeathSound()  => PlaySound(deathAudio);
        public void PlayJumpSound() => PlaySound(jumpAudio);
        
        private void PlaySound(AudioClip sound)
        {
            _audioSource.PlayOneShot(sound);
        }
        
    }
}