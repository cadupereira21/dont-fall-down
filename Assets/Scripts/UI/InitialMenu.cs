using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class InitialMenu : MonoBehaviour {
        public void Play() {
            SceneManager.LoadScene(1);
        }
    }
}