using UnityEngine;

namespace Game_Scene {
    public class CameraController : MonoBehaviour {
        
        [SerializeField]
        [Range(10, 200)]
        private float rotationSpeed = 100;

        private Touch _lastTouch;

        // Update is called once per frame
        private void Update() {
            if (Input.touchCount <= 0) return;
            
            Touch touch = Input.GetTouch(0);
            
            Debug.Log($"Touch phase: {touch.phase}");
            
            if (touch.phase == TouchPhase.Moved) {
                Vector2 deltaPosition = touch.position - _lastTouch.position;
                float rotationDiff = deltaPosition.x * rotationSpeed * Time.deltaTime;

                this.transform.Rotate(Vector3.up, rotationDiff);
            }
            
            _lastTouch = touch;
        }
    }
}
