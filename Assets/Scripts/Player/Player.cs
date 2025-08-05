using UnityEngine;

namespace Player {
    public class Player : MonoBehaviour {
        private void Update() {
            if (!(this.transform.position.y < -10)) return;
            
            GameStateManager.Instance.GameOver();
        }
    }
}