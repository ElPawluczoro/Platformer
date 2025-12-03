using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameMenu : MonoBehaviour
    {
        public static GameMenu Instance;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private Button menuButton;
        
        [SerializeField] private GameObject levelCompletePanel;
        [SerializeField] private GameObject nextLevelButton;

        private PlayerInputActions _inputActions;
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
            
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.UI.Enable();
            _inputActions.UI.OpenCloseMenu.performed += OpenCloseMenu;
        }

        public void OpenCloseMenu()
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

        private void OpenCloseMenu(InputAction.CallbackContext ctx)
        {
            OpenCloseMenu();
        }
        

        public void CloseMenu()
        {
            menuPanel.SetActive(false);
        }        
        public void RestartGame()
        {
            StartCoroutine(LevelRestarter.Instance.RestartLevel());
        }

        public void OpenLevelComplete()
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
                nextLevelButton.SetActive(false);
            
            levelCompletePanel.SetActive(true);
            menuButton.interactable = false;
            LevelRestarter.Instance.StopPlayer();
        }

        public void CloseLevelComplete()
        {
            levelCompletePanel.SetActive(false);
        }

        public void QuitGame()
        {
            MainGameController.Instance.QuitGame();
        }

        public void MainMenu()
        {
            MainGameController.Instance.MainMenu();
        }

        public void NextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}