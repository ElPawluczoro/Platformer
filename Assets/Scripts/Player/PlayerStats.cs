using System;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats Instance;

        private int _coins;
        private int _health;
        [SerializeField] private int  maxHealth;

        public int Coins => _coins;

        public int Health => _health;

        public int MaxHealth => maxHealth;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void AddCoin()
        {
            _coins++;
            Debug.Log(_coins);
        }

        public void AddHealth()
        {
            if (_health < maxHealth)
            {
                _health++;
            }
            Debug.Log(_health);
        }

        public void SubHealth()
        {
            _health--;
        }
    }
}