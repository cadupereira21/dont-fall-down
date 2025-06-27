using UnityEngine;

namespace Course_Library.Scripts {
    public class GameMenu : MonoBehaviour {
        [SerializeField] private GameObject gameMenuCanvas;

        private void Awake() {
            gameMenuCanvas.SetActive(true);
        }
    }
}