using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class UIController : Singleton<UIController>
    {
        public UIManager manager;

        private void Awake()
        {
            manager = GameObject.FindObjectOfType<UIManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var pauseUI = manager.GetPauseUI();
                var isOpenPauseUI = pauseUI.isOpenPauseUI;
                if (!isOpenPauseUI)
                {
                    pauseUI.Show();
                    pauseUI.SetBoolPauseUI(!isOpenPauseUI);
                }
                else
                {
                    pauseUI.Hide();
                    pauseUI.SetBoolPauseUI(!isOpenPauseUI);
                }
            }
        }
    }
}

