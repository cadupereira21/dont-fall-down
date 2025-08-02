using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState {
    PLAYING,
    PAUSED,
    GAME_OVER
}

public class GameStateManager : MonoBehaviour {
    public static GameStateManager Instance { get; private set; }
        
    public GameState CurrentGameState { get; private set; } = GameState.PLAYING;

    public static readonly UnityEvent OnGameOver = new ();
        
    public static readonly UnityEvent OnGamePaused = new ();

    public void Awake() {
        Instance = this;
        Time.timeScale = 1;
    }
        
    public void Pause() {
        if (CurrentGameState != GameState.PLAYING) return;
        Time.timeScale = 0;
        CurrentGameState = GameState.PAUSED;
        OnGamePaused.Invoke();
    }

    public void Resume() {
        if (CurrentGameState != GameState.PAUSED) return;
        Time.timeScale = 1;
        CurrentGameState = GameState.PLAYING;
    }

    public void Restart() {
        if (CurrentGameState is not (GameState.PAUSED or GameState.GAME_OVER)) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CurrentGameState = GameState.PLAYING;
        Time.timeScale = 1;
    }

    public void GameOver() {
        if (CurrentGameState != GameState.PLAYING) return;
        Time.timeScale = 0;
        CurrentGameState = GameState.GAME_OVER;
        OnGameOver.Invoke();
    }
}