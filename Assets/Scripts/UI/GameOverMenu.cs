using UnityEngine;

namespace UI {
    public class GameOverMenu : MonoBehaviour {
        public void RestartButtonClick() {
            GameStateManager.Instance.Restart();
        }
    }
}