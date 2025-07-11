using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Scene.Player {
    public class PlayerMovementController : MonoBehaviour {
        
        [Header("Movement buttons")]
        [SerializeField]
        private MovementButton moveForwardButton;
        
        [SerializeField]
        private MovementButton moveBackwardButton;
        
        [Header("Movement settings")]
        [SerializeField]
        [Range(300, 1500)]
        private float acceleration = 1000;
        
        [SerializeField]
        [Range(1, 30)]
        private float maxSpeed = 5;

        [SerializeField]
        [Tooltip("Focal point game object which the player will move towards. This will be used when adding force to the ball movement when the player moves up or down")]
        private GameObject focalPoint;

        private Rigidbody _playerRb;

        private void Start() {
            _playerRb = this.GetComponent<Rigidbody>();
            _playerRb.maxLinearVelocity = maxSpeed;
        }

        private void FixedUpdate() {
            if (moveForwardButton.isPressed) MoveForwardButtonClick();
            if (moveBackwardButton.isPressed) MoveBackwardButtonClick();
        }

        private void Move(int direction) {
            Vector3 directionToFocal = (this.transform.position - focalPoint.transform.position).normalized * direction;
            
            _playerRb.AddForce(new Vector3(directionToFocal.x, 0, directionToFocal.z) * (acceleration * Time.deltaTime),
                               ForceMode.Force);
        }

        private void MoveForwardButtonClick() {
            Move(1);
        }
        
        private void MoveBackwardButtonClick() {
            Move(-1);
        }
    }
}