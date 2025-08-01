using Logger;
using UnityEngine;
using ILogger = Logger.ILogger;

namespace Game_Scene.UI.LevelSelector {
    public class LevelSelector : MonoBehaviour {
        
        private LevelButton[] _levelButtons;
        
        private LevelButton _selectedLevel;
        
        public int SelectedLevelNumber { get; private set; } = -1;
        
        public void Awake() {
            _levelButtons = this.GetComponentsInChildren<LevelButton>();
        }

        private void Start() {
            for (int i = 0; i < _levelButtons.Length; i++) {
                int index = i; // Capture the current index
                _levelButtons[i].Init(index);
            }
        }

        private void OnEnable() {
            LevelButton.OnLevelSelected.AddListener(SelectLevel);
        }
        
        private void OnDisable() {
            LevelButton.OnLevelSelected.RemoveListener(SelectLevel);
        }

        private void SelectLevel(int index) {
            if (index == SelectedLevelNumber - 1) return;

            if (_selectedLevel != null) {
                _selectedLevel.UnselectLevel();
            }

            _selectedLevel = _levelButtons[index];
            _selectedLevel.SelectLevel();
            
            SelectedLevelNumber = index+1;
        }
        
    }
}