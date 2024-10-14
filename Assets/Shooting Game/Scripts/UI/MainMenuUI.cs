using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnQuit;

        private void Start()
        {
            btnPlay.onClick.AddListener(ButtonPlay);
            btnQuit.onClick.AddListener(ButtonQuit);
        }

        public void ButtonPlay()
        {
            SceneManagerStatic.SceneLoad(Constants.GAMEPLAY_SCENE);
            Hide();
        }

        public void ButtonQuit()
        {
            Application.Quit();
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}

