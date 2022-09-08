using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class TitleCard : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnQuit;

        [SerializeField] private static string nameMainScene = "Main";

        void Start()
        {
            btnPlay.onClick.AddListener(Play);
            btnQuit.onClick.AddListener(Play);
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
