using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game_Scene.UI.LevelSelector {
    [RequireComponent(typeof(Button), typeof(Outline))]
    public class LevelButton : MonoBehaviour {
        private Button _button;
        private Outline _outline;
        
        private readonly Color _selectedColor = new Color(255, 0, 0, 255);
        private readonly Color _unselectedColor = new Color(255, 0, 0, 0);
        
        private int _levelIndex;
        
        public static readonly UnityEvent<int> OnLevelSelected = new ();
        
        public void Init(int index) {
            _levelIndex = index;
            _button.onClick.AddListener(() => OnLevelSelected.Invoke(_levelIndex));
        }

        public void Awake() {
            _button = this.GetComponent<Button>();
            _outline = this.GetComponent<Outline>();
        }

        private void OnEnable() {
            _outline.effectColor = _unselectedColor;
        }

        public void SelectLevel() {
            _outline.effectColor = _selectedColor;
        }

        public void UnselectLevel() {
            _outline.effectColor = _unselectedColor;
        }
    }
}