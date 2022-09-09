using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private Button pausebttn;
        [SerializeField] private Button resumebttn;
        [SerializeField] private Button menuBttn;
        
        [SerializeField] private GameObject pauseOverlay;
        [SerializeField] private static string nameMenuScene = "Main_Title";

        void Start()
        {
            pausebttn.onClick.AddListener(PauseGame);
            resumebttn.onClick.AddListener(Resume);
            menuBttn.onClick.AddListener(Menu);
        }

        private void Menu()
        {
            GameManager.music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nameMenuScene);
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
            pauseOverlay.SetActive(true);
        }
        
        private void Resume()
        {
            pauseOverlay.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
