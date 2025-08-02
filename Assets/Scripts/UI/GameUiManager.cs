using UnityEngine;

namespace UI {
    public class GameUiManager : MonoBehaviour {
        
        [SerializeField]
        private GameOverlay gameOverlay;
        
        [SerializeField]
        private PauseMenu pauseMenu;
        
        [SerializeField]
        private GameOverMenu gameOverMenu;
        
        private void Awake() {
            gameOverlay.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
        }

        private void OnEnable() {
            GameStateManager.OnGamePaused.AddListener(ShowPauseMenu);
            GameStateManager.OnGameOver.AddListener(ShowGameOverMenu);
        }
        
        private void OnDisable() {
            GameStateManager.OnGamePaused.RemoveListener(ShowPauseMenu);
            GameStateManager.OnGameOver.RemoveListener(ShowGameOverMenu);
        }
        
        private void OnDestroy() {
            GameStateManager.OnGamePaused.RemoveListener(ShowPauseMenu);
            GameStateManager.OnGameOver.RemoveListener(ShowGameOverMenu);
        }

        private void ShowPauseMenu() {
            pauseMenu.gameObject.SetActive(true);
        }
        
        private void ShowGameOverMenu() {
            gameOverlay.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(true);
        }
    }
}