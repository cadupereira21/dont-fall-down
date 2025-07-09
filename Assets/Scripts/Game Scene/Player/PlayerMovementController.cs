using UnityEngine;

namespace Game_Scene.Player {
    public class PlayerMovementController : MonoBehaviour {
        
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

        private void Update() {
            Vector3 directionToFocal = (this.transform.position - focalPoint.transform.position).normalized;
            
            _playerRb.AddForce(new Vector3(-directionToFocal.x, 0, -directionToFocal.z) * (acceleration * Time.deltaTime),
                               ForceMode.Force);
        }
    }
}