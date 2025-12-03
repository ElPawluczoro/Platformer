using System;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private TMP_Text gameVersionText;
        public void QuitGame()
        {
            MainGameController.Instance.QuitGame();
        }

        public void ChooseLevel()
        {
            SceneManager.LoadScene("LevelSelect");
        }

        private void Start()
        {
            gameVersionText.text = $"Game Version {MainGameController.Instance.GameVersion}";
        }
    }
}