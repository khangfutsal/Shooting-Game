using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class GameController : Singleton<GameController>
    {
        public GameManager manager;
        public float curTime;
        private void Update()
        {
            UpdateTime();
        }

        public void UpdateTime()
        {
            curTime += Time.deltaTime;
            UIController.Ins.manager.GetGamePlayUI().UpdateTimeUI(curTime);
        }
    }

}
