using UnityEngine;

namespace Game_Scene {
    public class CameraController : MonoBehaviour {
        public float rotationSpeed;

        // Update is called once per frame
        private void Update() {
            float horizontalInput = Input.GetAxis("Horizontal");

            this.transform.Rotate(Vector3.up, -horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
