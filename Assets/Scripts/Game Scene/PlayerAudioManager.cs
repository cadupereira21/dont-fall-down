using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class PlayerAudioManager : MonoBehaviour {
        [SerializeField] private AudioClip powerUpSfx;

        [SerializeField] private AudioClip bumpSfx;
        
        private AudioSource _playerAudioSource;

        private void Awake() {
            _playerAudioSource = this.GetComponent<AudioSource>();
        }

        public void PlayPowerUpSound() {
            _playerAudioSource.PlayOneShot(powerUpSfx, 1.4f);
        }

        public void PlayBumpSound() {
            _playerAudioSource.PlayOneShot(bumpSfx, 1.5f);
        }
    }
}