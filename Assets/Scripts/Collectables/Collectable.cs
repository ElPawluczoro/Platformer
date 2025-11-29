using System;
using Audio;
using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (Collect())
                {
                    gameObject.SetActive(false);
                    PlaySound();
                }
            }
        }

        protected abstract bool Collect();
        protected abstract void PlaySound();
    }
}