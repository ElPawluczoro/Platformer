using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

namespace Game
{
    public class GameMenu : MonoBehaviour
    {
        public static GameMenu Instance;
        [SerializeField] private GameObject menuPanel;

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
    }
}