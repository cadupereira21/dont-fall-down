using Enemy.Spawn;
using TMPro;
using UnityEngine;

namespace UI {
    public class GameOverlay : MonoBehaviour {
        
        [SerializeField]
        private TextMeshProUGUI waveText;

        private void Awake() {
            this.gameObject.SetActive(true);
            waveText.gameObject.SetActive(true);
            waveText.text = "WAVE: 1";
        }

        private void OnEnable() {
            EnemySpawnManager.OnNewWaveSpawned.AddListener(SetWaveText);
        }

        private void OnDisable() {
            EnemySpawnManager.OnNewWaveSpawned.RemoveListener(SetWaveText);
        }

        private void OnDestroy() {
            EnemySpawnManager.OnNewWaveSpawned.RemoveListener(SetWaveText);
        }

        private void SetWaveText(int wave) {
            waveText.text = $"WAVE: {wave.ToString()}";
        }

        public void OnPauseButtonClick() {
            GameStateManager.Instance.Pause();
        }
    }
}