using PlayerModifier.Buffs;
using UnityEngine;

namespace Player {
    public class PlayerCollisionController : MonoBehaviour {
        
        private const string TAG_BUFF = "Buff";

        private const string TAG_ENEMY = "Enemy";
        
        private PlayerAudioManager _audioManager;
        
        private PlayerBuffController _buffController;

        private void Awake() {
            _audioManager = this.GetComponent<PlayerAudioManager>();
            _buffController = this.GetComponent<PlayerBuffController>();
        }

        private void OnTriggerEnter(Collider other) {
            if (!other.gameObject.CompareTag(TAG_BUFF)) return;
            
            _audioManager.PlayPowerUpSound();
            
            _buffController.SetBuff(other.gameObject);
        }

        private void OnCollisionEnter(Collision other) {
            if (!other.gameObject.CompareTag(TAG_ENEMY)) return;
            
            _audioManager.PlayBumpSound();
            if (!_buffController.HasBuff) return;
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.transform.position - this.transform.position).normalized;

            enemyRb.AddForce(awayFromPlayer * ((KnockbackBuff) _buffController.ActiveBuff).KnockbackStrength,
                             ForceMode.Impulse);
        }
    }
}