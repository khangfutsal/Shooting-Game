using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GamePlayUI gamePlayUI;
        [SerializeField] private ShopUI shopUI;
        [SerializeField] private WinUI winUI;
        [SerializeField] private LoseUI loseUI;
        [SerializeField] private PauseUI pauseUI;
        [SerializeField] private MainMenuUI mainMenuUI;
        public ShopUI GetShopUI() => shopUI;
        public GamePlayUI GetGamePlayUI() => gamePlayUI;
        public LoseUI GetLoseUI() => loseUI;
        public WinUI GetWinUI() => winUI;
        public PauseUI GetPauseUI() => pauseUI;
        public MainMenuUI GetMainMenuUI() => mainMenuUI;


        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (shopUI == null)
            {
                shopUI = GameObject.FindObjectOfType<ShopUI>();
            }
            if (gamePlayUI == null)
            {
                gamePlayUI = GameObject.FindObjectOfType<GamePlayUI>();
            }
            if (loseUI == null)
            {
                loseUI = GameObject.FindObjectOfType<LoseUI>();
            }
            if (winUI == null)
            {
                winUI = GameObject.FindObjectOfType<WinUI>();
            }
            if (pauseUI == null)
            {
                pauseUI = GameObject.FindObjectOfType<PauseUI>();
            }
            if (mainMenuUI == null)
            {
                mainMenuUI = GameObject.FindObjectOfType<MainMenuUI>();
            }

            Debug.Log("Scene loaded: " + scene.name);
        }

    }
}

