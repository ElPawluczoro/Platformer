using System;
using UI;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats Instance;

        private int _coins;
        private int _health;
        [SerializeField]
        private int  maxHealth;

        public delegate void OnHealthChanged(int health);
        public event OnHealthChanged onHealthChanged;
        public delegate void OnCoinsChanged(int coins);
        public event OnCoinsChanged onCoinsChanged;
        
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
            if (onCoinsChanged != null) onCoinsChanged.Invoke(_coins);
        }

        public void AddHealth()
        {
            if (_health < maxHealth)
            {
                _health++;
            }

            if (onHealthChanged != null) onHealthChanged.Invoke(_health);
        }

        public void SubHealth()
        {
            _health--;
            if (onHealthChanged != null) onHealthChanged.Invoke(_health);
        }
    }
}