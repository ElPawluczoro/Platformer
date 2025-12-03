using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MainGameController : MonoBehaviour
    {
        public static MainGameController Instance;
        
        private GameSave _save;

        public readonly string GameVersion = "0.1";
        
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
            
            DontDestroyOnLoad(gameObject);
            _save = SaveSystemBinary.Load();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void SetLevelAsCompleted(int levelID)
        {
            if (!_save.completedLevels.Contains(levelID))
            {
                _save.completedLevels.Add(levelID);
                SaveSystemBinary.Save(_save);
            }
        }

        public List<int> LoadCompletedLevelsList()
        {
            return _save.completedLevels;
        }
    }
}