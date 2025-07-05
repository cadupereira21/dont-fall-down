using System;
using UnityEngine;

namespace Game_Scene.UI {
    public class GameOverMenu : MonoBehaviour {
        public void RestartButtonClick() {
            GameStateManager.Instance.Restart();
        }
    }
}