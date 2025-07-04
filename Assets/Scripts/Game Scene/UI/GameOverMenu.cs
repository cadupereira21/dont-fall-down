using System;
using Game_Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Course_Library.Scripts {
    public class GameOverMenu : MonoBehaviour {
        [SerializeField] private Transform playerTransform;

        [SerializeField] private GameObject gameOverCanvas;

        [SerializeField] private GameObject gameCanvas;

        private void Awake() {
            gameOverCanvas.SetActive(false);
        }

        private void Update() {
            if (!(playerTransform.position.y < -10)) return;
            GameStateManager.Instance.GameOver();
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
        }

        public void Restart() {
            GameStateManager.Instance.Restart();
        }
    }
}