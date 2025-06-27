using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class PlayerController : MonoBehaviour {
        private const string TagPowerUp = "PowerUp";

        private const string TagEnemy = "Enemy";

        private const string VerticalAxis = "Vertical";

        private const string CameraFocalPoint = "CameraFocalPoint";

        [SerializeField] private GameObject powerUpIndicator;

        [SerializeField] private float playerSpeed;
        
        private PlayerAudioManager _playerAudioManager;

        private PowerUp _powerUp;

        private GameObject _focalPoint;

        private Rigidbody _playerRb;
        
        private bool _hasPowerUp;

        private void Awake() {
            _focalPoint = GameObject.Find(CameraFocalPoint);
        }

        private void Start() {
            _playerRb = this.GetComponent<Rigidbody>();
            _playerAudioManager = this.GetComponent<PlayerAudioManager>();
        }

        private void Update() {
            float verticalInput = Input.GetAxis(VerticalAxis);

            _playerRb.AddForce(_focalPoint.transform.forward * (verticalInput * this.playerSpeed * Time.deltaTime),
                               ForceMode.Force);
        }

        private void OnTriggerEnter(Collider other) {
            if (!other.gameObject.CompareTag(TagPowerUp)) return;
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
            if (other.gameObject.CompareTag(TagEnemy)) {
                _playerAudioManager.PlayBumpSound();
                if (!_hasPowerUp) return;
                var enemyRb = other.gameObject.GetComponent<Rigidbody>();
                var awayFromPlayer = (other.transform.position - this.transform.position).normalized;

                enemyRb.AddForce(awayFromPlayer * ((KnockbackPowerUp)this._powerUp).GetKnockBackStrength,
                                 ForceMode.Impulse);
            }
        }

        private IEnumerator PowerUpCountdownRoutine() {
            yield return new WaitForSeconds(_powerUp.GetDuration);
            _hasPowerUp = false;
            _powerUp = null;
            powerUpIndicator.SetActive(false);
        }
    }
}