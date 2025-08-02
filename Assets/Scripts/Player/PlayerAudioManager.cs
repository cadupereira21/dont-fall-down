using UnityEngine;

namespace Player {
    public class PlayerAudioManager : MonoBehaviour {
        
        [Header("Buff Sounds")]
        [SerializeField] private AudioClip buffSfx;
        
        [SerializeField] 
        [Range(1, 1.5f)]
        private float buffSfxVolume = 1.4f;

        [Header("Bump Sounds")]
        [SerializeField] private AudioClip bumpSfx;
        [Range(1, 1.5f)]
        [SerializeField] private float bumpSfxVolume = 1.5f;
        
        private AudioSource _playerAudioSource;

        private void Awake() {
            _playerAudioSource = this.GetComponent<AudioSource>();
        }

        public void PlayPowerUpSound() {
            _playerAudioSource.PlayOneShot(buffSfx, buffSfxVolume);
        }

        public void PlayBumpSound() {
            _playerAudioSource.PlayOneShot(bumpSfx, bumpSfxVolume);
        }
    }
}