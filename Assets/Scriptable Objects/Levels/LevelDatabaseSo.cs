using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scriptable_Objects.Levels {
    [CreateAssetMenu(fileName = "LevelDatabase", menuName = "Levels")]
    public class LevelDatabaseSo : ScriptableObject {
        public LevelData[] levels;
    }

    [Serializable]
    public struct LevelData {
        [field: SerializeField] private string levelName;
        [field: SerializeField] private int levelIndex;
        [field: SerializeField] private Sprite levelImage;
        [field: SerializeField] private bool isLocked;
        [field: SerializeField] private string sceneName;
        
        public string LevelName => levelName;
        public int LevelIndex => levelIndex;
        public Sprite LevelImage => levelImage;
        public bool IsLocked => isLocked;
        public string SceneName => sceneName;
    }
}