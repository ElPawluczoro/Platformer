using System;
using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if(Collect()) gameObject.SetActive(false);
            }
        }

        protected abstract bool Collect();
    }
}