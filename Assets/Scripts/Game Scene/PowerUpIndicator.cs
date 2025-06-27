using UnityEngine;

namespace Course_Library.Scripts {
    public class PowerUpIndicator : MonoBehaviour {
        [SerializeField] private Transform playerTransform;

        private void Update() {
            this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - 0.2f,
                                                  playerTransform.position.z);
        }
    }
}