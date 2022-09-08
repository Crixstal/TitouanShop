using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class TitleCard : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnQuit;

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
        }

        private void Play()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nameMainScene);
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}
