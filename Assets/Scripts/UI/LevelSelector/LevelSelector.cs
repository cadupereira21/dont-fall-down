using Scriptable_Objects.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.LevelSelector {
    public class LevelSelector : MonoBehaviour {
        
        [SerializeField] private LevelDatabaseSo levelDatabaseSo;
        [SerializeField] private GameObject levelButtonPrefab;
        
        private LevelButton[] _levelButtons;
        
        private LevelButton _selectedLevel;

        private int _selectedLevelNumber = -1;
        private string _selectedLevelSceneName = "";
        
        public void Awake() {
            //Destroy every child gameObjects
            for(int i = 0; i < this.transform.childCount; i++) {
                Destroy(this.transform.GetChild(i).gameObject);
            }
            
            _levelButtons = new LevelButton[levelDatabaseSo.levels.Length];
            for (int i = 0; i < levelDatabaseSo.levels.Length; i++) {
                LevelData levelData = levelDatabaseSo.levels[i];
                GameObject levelButtonInstance = Instantiate(levelButtonPrefab, this.transform);
                LevelButton levelButton = levelButtonInstance.GetComponent<LevelButton>();
                levelButton.Init(i, levelData.LevelName, levelData.LevelImage, levelData.IsLocked, levelData.SceneName);
                _levelButtons[i] = levelButton;
            }
        }

        private void OnEnable() {
            LevelButton.OnLevelSelected.AddListener(SelectLevel);
        }
        
        private void OnDisable() {
            LevelButton.OnLevelSelected.RemoveListener(SelectLevel);
        }

        private void SelectLevel(int index, string sceneName) {
            if (index == _selectedLevelNumber - 1) return;

            if (_selectedLevel != null) {
                _selectedLevel.UnselectLevel();
            }

            _selectedLevel = _levelButtons[index];
            _selectedLevel.SelectLevel();
            
            _selectedLevelNumber = index+1;
            _selectedLevelSceneName = sceneName;
        }

        public void LoadLevel() {
            SceneManager.LoadScene(_selectedLevelSceneName);
        }
    }
}