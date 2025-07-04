using UnityEngine;
using UnityEngine.SceneManagement;

namespace Initial_Menu_Scene {
    public class InitialMenu : MonoBehaviour {
        public void Play() {
            SceneManager.LoadScene(1);
        }
    }
}