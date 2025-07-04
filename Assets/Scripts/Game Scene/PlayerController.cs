using System.Collections;
using System.Linq;
using Game_Scene.Buffs;
using UnityEngine;

namespace Game_Scene {
    public class PlayerController : MonoBehaviour {
        private const string TAG_POWER_UP = "PowerUp";

        private const string TAG_ENEMY = "Enemy";

        private const string VERTICAL_AXIS = "Vertical";

        private const string CAMERA_FOCAL_POINT = "CameraFocalPoint";

        [SerializeField] private GameObject powerUpIndicator;

        [SerializeField] private float playerSpeed;
        
        private PlayerAudioManager _playerAudioManager;

        private PowerUp _powerUp;

        private GameObject _focalPoint;

        private Rigidbody _playerRb;
        
        private bool _hasPowerUp;

        private void Awake() {
            _focalPoint = GameObject.Find(CAMERA_FOCAL_POINT);
        }

        private void Start() {
            _playerRb = this.GetComponent<Rigidbody>();
            _playerAudioManager = this.GetComponent<PlayerAudioManager>();
        }

        private void Update() {
            float verticalInput = Input.GetAxis(VERTICAL_AXIS);

            _playerRb.AddForce(_focalPoint.transform.forward * (verticalInput * this.playerSpeed * Time.deltaTime),
                               ForceMode.Force);
        }

        private void OnTriggerEnter(Collider other) {
            if (!other.gameObject.CompareTag(TAG_POWER_UP)) return;
            _playerAudioManager.PlayPowerUpSound();
            
            if (_hasPowerUp) {
                this.StopCoroutine(PowerUpCountdownRoutine());
                _hasPowerUp = false;
                _powerUp = null;
                powerUpIndicator.SetActive(false);
            }
            _powerUp = other.gameObject.GetComponent<PowerUp>();
            _hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            this.StartCoroutine(PowerUpCountdownRoutine());
            Debug.Log("Player collected power-up: " + _powerUp.GetType().ToString().Split(".").Last());
        }

        private void OnCollisionEnter(Collision other) {
            if (!other.gameObject.CompareTag(TAG_ENEMY)) return;
            
            _playerAudioManager.PlayBumpSound();
            if (!_hasPowerUp) return;
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.transform.position - this.transform.position).normalized;

            enemyRb.AddForce(awayFromPlayer * ((KnockbackPowerUp)this._powerUp).GetKnockBackStrength,
                             ForceMode.Impulse);
        }

        private IEnumerator PowerUpCountdownRoutine() {
            yield return new WaitForSeconds(_powerUp.GetDuration);
            _hasPowerUp = false;
            _powerUp = null;
            powerUpIndicator.SetActive(false);
        }
    }
}