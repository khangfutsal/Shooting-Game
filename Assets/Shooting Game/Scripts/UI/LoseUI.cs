using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class LoseUI : MonoBehaviour
    {
        [SerializeField] private Button btnRetry;
        [SerializeField] private Button btnMenu;
        private void Start()
        {
            btnRetry.onClick.AddListener(ButtonRetry);
            btnMenu.onClick.AddListener(ButtonMenu);
            Hide();
        }

        public void ButtonRetry()
        {
            SceneManagerStatic.SceneLoadAgain(Constants.GAMEPLAY_SCENE);
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
    }
}

