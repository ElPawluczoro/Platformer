using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerStatsUIController : MonoBehaviour
    {
        public static PlayerStatsUIController Instance;

        
        [SerializeField, Tooltip("Must be in order")] 
        private Image[] healthIcons;
        [SerializeField] private Sprite healthSprite;
        [SerializeField] private Sprite emptyHealthSprite;
        [SerializeField] private TMP_Text coinsText;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance =  this;
            }
            
            PlayerStats.Instance.onHealthChanged += SetHealth;
            PlayerStats.Instance.onCoinsChanged += SetCoins;
            
            PlayerStats.Instance.AddHealth();
        }
        
        
        private void SetHealth(int health)
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                healthIcons[i].sprite = i < health ? healthSprite : emptyHealthSprite;
            }
        }

        private void SetCoins(int coins)
        {
            coinsText.text = coins.ToString();
        }
    }
}