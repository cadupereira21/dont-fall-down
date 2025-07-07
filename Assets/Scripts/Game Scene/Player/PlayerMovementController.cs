using UnityEngine;

namespace Game_Scene.Player {
    public class PlayerMovementController : MonoBehaviour {
        
        private const string VERTICAL_AXIS = "Vertical";
        
        [SerializeField]
        [Range(100, 1000)]
        private float playerSpeed = 550;

        [SerializeField]
        [Tooltip("Focal point game object which the player will move towards. This will be used when adding force to the ball movement when the player moves up or down")]
        private GameObject focalPoint;

        private Rigidbody _playerRb;

        private void Start() {
            _playerRb = this.GetComponent<Rigidbody>();
        }

        private void Update() {
            float verticalInput = Input.GetAxis(VERTICAL_AXIS);

            _playerRb.AddForce(focalPoint.transform.forward * (verticalInput * playerSpeed * Time.deltaTime),
                               ForceMode.Force);
        }
    }
}