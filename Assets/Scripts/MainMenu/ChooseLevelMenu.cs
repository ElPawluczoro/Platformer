using System;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class ChooseLevelMenu : MonoBehaviour
    {
        [SerializeField] List<Button> levelButtons = new List<Button>();

        private void Start()
        {
            LoadLevels();
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene("level" + levelName);
        }

        public void MainMenu()
        {
            MainGameController.Instance.MainMenu();
        }

        public void LoadLevels()
        {
            var loadCompletedLevelsList = MainGameController.Instance.LoadCompletedLevelsList();
            for (int i = 0; i < levelButtons.Count; i++)
            {
                //Debug.Log(MainGameController.Instance.GetLevelBestScore(i));
                levelButtons[i].gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text =
                    MainGameController.Instance.GetLevelBestScore(i) + "/" +
                    levelButtons[i].gameObject.GetComponent<MaxScore>().maxScore;
                if(i >= levelButtons.Count - 1) return;
                if (!loadCompletedLevelsList.Contains(i))
                {
                    levelButtons[i + 1].interactable = false;
                    continue;
                }
                
            }
        }
    }
}