using System;
using UnityEngine;

namespace Game
{
    public class LevelInfo : MonoBehaviour
    {
        public static LevelInfo Instance;
        
        [SerializeField] private int levelID;
        
        public int LevelID => levelID;

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
    }
}