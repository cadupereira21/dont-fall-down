using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Scene {
    public class CameraController : MonoBehaviour {
        
        [SerializeField]
        [Range(1, 100)]
        private float rotationSpeed = 50;

        private Touch _lastTouch;
        
        private static bool IsTouchOverUI => EventSystem.current.IsPointerOverGameObject();

        private void Awake() {
            #if UNITY_EDITOR
                rotationSpeed = rotationSpeed * 5;
            #endif
        }

        // Update is called once per frame
        private void Update() {
            switch (Input.touchCount) {
                case <= 0:
                    return;
                case 1: {
                    RotateBasedOnTouch(Input.GetTouch(0));
                    break;
                }
                case > 1: {
                    foreach (Touch touch in Input.touches) {
                        if (IsTouchOverUI) continue;
                        
                        RotateBasedOnTouch(touch);
                        break;
                    }

                    break;
                }
            }
        }

        private void RotateBasedOnTouch(Touch touch) {
            if (touch.phase == TouchPhase.Moved) {
                Vector2 deltaPosition = touch.position - _lastTouch.position;
                float rotationDiff = deltaPosition.x * rotationSpeed * Time.deltaTime;

                this.transform.Rotate(Vector3.up, rotationDiff);
            }
            
            _lastTouch = touch;
        }
    }
}
