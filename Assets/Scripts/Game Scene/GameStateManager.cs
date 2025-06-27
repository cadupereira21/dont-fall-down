using UnityEngine;
using UnityEngine.SceneManagement;

namespace Course_Library.Scripts.Game_Scene {
    public enum GameState {
        PLAYING,
        PAUSED,
        GAME_OVER
    }

    public class GameStateManager : MonoBehaviour {
        public static GameStateManager instance { get; private set; }

        public void Awake() {
            instance = this;
            Time.timeScale = 1;
        }

        public GameState currentGameState { get; private set; } = GameState.PLAYING;

        public void Pause() {
            if (currentGameState != GameState.PLAYING) return;
            Time.timeScale = 0;
            currentGameState = GameState.PAUSED;
        }

        public void Resume() {
            if (currentGameState != GameState.PAUSED) return;
            Time.timeScale = 1;
            currentGameState = GameState.PLAYING;
        }

        public void Restart() {
            if (currentGameState is not (GameState.PAUSED or GameState.GAME_OVER)) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            currentGameState = GameState.PLAYING;
            Time.timeScale = 1;
        }

        public void GameOver() {
            if (currentGameState != GameState.PLAYING) return;
            Time.timeScale = 0;
            currentGameState = GameState.GAME_OVER;
        }
    }
}