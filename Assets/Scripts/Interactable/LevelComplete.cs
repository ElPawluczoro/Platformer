using System;
using Game;
using UnityEngine;

namespace Interactable
{
    public class LevelComplete : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) CompleteLevel();

        }

        private void CompleteLevel()
        {
            MainGameController.Instance.SetLevelAsCompleted(LevelInfo.Instance.LevelID);
            GameMenu.Instance.OpenLevelComplete();
        }
        
    }
}