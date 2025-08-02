using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.LevelSelector {
    [RequireComponent(typeof(Button), typeof(Outline))]
    public class LevelButton : MonoBehaviour {
        
        [SerializeField] private TextMeshProUGUI levelNameText;
        [SerializeField] private GameObject lockedIcon;
        [SerializeField] private Image levelImage;
        
        private Button _button;
        private Outline _outline;
        
        private readonly Color _selectedColor = new (255, 0, 0, 255);
        private readonly Color _unselectedColor = new (255, 0, 0, 0);
        
        private int _levelIndex;
        private string _levelSceneName;
        private bool _isLocked;
        
        public static readonly UnityEvent<int, string> OnLevelSelected = new ();
        
        public void Init(int index, string levelName, Sprite levelImageSprite, bool isLocked, string levelSceneName) {
            _levelIndex = index;
            _levelSceneName = levelSceneName;
            _isLocked = isLocked;
            
            levelNameText.text = $"{index+1}. {levelName}";
            lockedIcon.SetActive(isLocked);
            levelImage.sprite = levelImageSprite;
        }

        public void Awake() {
            _button = this.GetComponent<Button>();
            _outline = this.GetComponent<Outline>();
        }

        private void Start() {
            _button.onClick.AddListener(() => {
                if (!_isLocked) OnLevelSelected.Invoke(_levelIndex, _levelSceneName);
            });
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