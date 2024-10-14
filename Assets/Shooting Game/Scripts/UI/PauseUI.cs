using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnMenu;
        public bool isOpenPauseUI;

        private void Start()
        {
            btnPlay.onClick.AddListener(ButtonPlay);
            btnMenu.onClick.AddListener(ButtonMenu);
            Hide();
        }

        public void ButtonPlay()
        {
            isOpenPauseUI = false;
            Hide();
        }

        public void ButtonMenu()
        {
            SceneManagerStatic.SceneUnload(Constants.GAMEPLAY_SCENE);
            UIController.Ins.manager.GetMainMenuUI().Show();
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void SetBoolPauseUI(bool _bool)
        {
            this.isOpenPauseUI = _bool;
        }
    }
}

