using UnityEngine;

namespace Game_Scene {
    public class GameMusicManager : MonoBehaviour {
        [SerializeField] private AudioSource cameraAudioSource;

        private void Update() {
            if (GameStateManager.Instance.CurrentGameState == GameState.GAME_OVER) {
                if (cameraAudioSource.isPlaying) cameraAudioSource.Stop();
            }
            else {
                if (!cameraAudioSource.isPlaying) cameraAudioSource.Play();
            }
        }
    }
}
