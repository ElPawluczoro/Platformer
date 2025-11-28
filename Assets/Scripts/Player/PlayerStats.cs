using System;
using Game;
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
                Destroy(gameObject);
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

        public void ResetCoins()
        {
            _coins = 0;
            if (onCoinsChanged != null) onCoinsChanged.Invoke(_coins);
        }
        public void AddHealth()
        {
            if (_health >= maxHealth) return;

            _health++;
            if (onHealthChanged != null) onHealthChanged.Invoke(_health);
        }

        public void SubHealth()
        {
            _health--;
            if (onHealthChanged != null) onHealthChanged.Invoke(_health);
            if(_health <= 0) StartCoroutine(LevelRestarter.Instance.RestartLevel());
        }
    }
}