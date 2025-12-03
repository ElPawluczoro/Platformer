using System.Collections.Generic;
using Player;
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
                Debug.Log(_save.bestScore[levelID]);
            }

            if (PlayerStats.Instance.Coins >= _save.bestScore[levelID])
            {
                _save.bestScore[levelID] = PlayerStats.Instance.Coins;
            }
            SaveSystemBinary.Save(_save);
        }

        public List<int> LoadCompletedLevelsList()
        {
            return _save.completedLevels;
        }

        public int GetLevelBestScore(int i)
        {
            return _save.bestScore.GetValueOrDefault(i, 0);
        }
    }
}