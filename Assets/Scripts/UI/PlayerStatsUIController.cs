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
        
        [SerializeField] private Sprite scoreSprite;
        
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
            coinsText.text = ConvertToSprites(coins);
        }

        private string ConvertToSprites(int coins)
        {
            string s = coins.ToString();
            string result = "";

            foreach (char c in s)
            {
                result += $"<sprite name=\"{c}\">";
            }
            
            return result;
        }
    }
}










