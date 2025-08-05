using UnityEngine;

namespace UI {
    public class PauseMenu : MonoBehaviour {
        public void ResumeButtonClick() {
            GameStateManager.Instance.Resume();
            this.gameObject.SetActive(false);
        }

        public void RestartButtonClick() {
            GameStateManager.Instance.Restart();
        }
    }
}