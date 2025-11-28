using UnityEngine;

namespace Game
{
    public class LevelInformation : MonoBehaviour
    {
        public static LevelInformation Instance;
        
        public float minimalY = -25;

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
    }
}