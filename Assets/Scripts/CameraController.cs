using UnityEngine;

public class CameraController : MonoBehaviour {
        
    [SerializeField]
    [Range(1, 100)]
    private float rotationSpeed = 50;
        
    [SerializeField]
    [Range(0, 10)]
    private float rotationDeadZone = 1;
        
    private Touch _lastTouch;

    private int _lastTouchId;
        
    private void Awake() {
        #if UNITY_EDITOR
        rotationSpeed = rotationSpeed * 5;
        #endif
    }

    private void LateUpdate() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RotateBasedOnTouch(touch);
        }
    }

    private void RotateBasedOnTouch(Touch touch) {
        if (touch.phase == TouchPhase.Moved) {
            Vector2 deltaPosition = touch.position - _lastTouch.position;
            float rotationDiff = deltaPosition.x * rotationSpeed * Time.deltaTime;

            if (Mathf.Abs(rotationDiff) > rotationDeadZone) {
                this.transform.Rotate(Vector3.up, rotationDiff);
            }
        }

        _lastTouch = touch;
    }
}