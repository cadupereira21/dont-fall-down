using UnityEngine;

namespace Game_Scene.UI {
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