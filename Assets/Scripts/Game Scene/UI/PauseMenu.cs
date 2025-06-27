using System;
using Course_Library.Scripts.Game_Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Course_Library.Scripts {
    public class PauseMenu : MonoBehaviour {
        [SerializeField] private GameObject pauseMenu;

        private void Awake() {
            pauseMenu.SetActive(false);
        }

        private void Update() {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (GameStateManager.instance.currentGameState == GameState.PAUSED) {
                Resume();
            }
            else {
                Pause();
            }
        }

        private void Pause() {
            GameStateManager.instance.Pause();
            pauseMenu.SetActive(true);
        }

        public void Resume() {
            GameStateManager.instance.Resume();
            pauseMenu.SetActive(false);
        }

        public void Restart() {
            GameStateManager.instance.Restart();
        }
    }
}