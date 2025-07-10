using System;
using UnityEngine;

namespace Game_Scene {
    public class CameraController : MonoBehaviour {
        
        [SerializeField]
        [Range(1, 100)]
        private float rotationSpeed = 50;

        private Touch _lastTouch;

        private void Awake() {
            #if UNITY_EDITOR
                rotationSpeed = rotationSpeed * 5;
            #endif
        }

        // Update is called once per frame
        private void Update() {
            if (Input.touchCount <= 0) return;
            
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved) {
                Vector2 deltaPosition = touch.position - _lastTouch.position;
                float rotationDiff = deltaPosition.x * rotationSpeed * Time.deltaTime;

                this.transform.Rotate(Vector3.up, rotationDiff);
            }
            
            _lastTouch = touch;
        }
    }
}
