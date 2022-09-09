using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class TitleCard : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnQuit;
        [SerializeField] private Button btnOption;

        [SerializeField] private static string nameMainScene = "Main";

        private void Awake()
        {
#if UNITY_STANDALONE_WIN
            Screen.SetResolution(600,2000, true);
            Screen.orientation = ScreenOrientation.Portrait;
#endif
        }
        void Start()
        {
            btnPlay.onClick.AddListener(Play);
            btnQuit.onClick.AddListener(Quit);
            btnOption.onClick.AddListener(Options);
        }

        public void LaunchEventSound()
        {
            EventInstance event_Sound = RuntimeManager.CreateInstance("event:/UI/ClicButton");
            event_Sound.start();
            event_Sound.release();
        }
        
        private void Play()
        {
            LaunchEventSound();
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nameMainScene);
        }

        private void Quit()
        {           
            LaunchEventSound();
            Application.Quit();
        }

        private void Options()
        {
            LaunchEventSound();
        }
    }
}
