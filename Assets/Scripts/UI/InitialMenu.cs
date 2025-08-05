using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class InitialMenu : MonoBehaviour {
        
        [Header("Screens")]
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject levelSelectionScreen;

        [Header("Navigation Buttons")]
        [SerializeField] private Button levelButton;
        [SerializeField] private Button levelBackButton;

        private void OnEnable() {
            mainMenuScreen.SetActive(true);
            levelSelectionScreen.SetActive(false);
            
            levelButton.onClick.AddListener(ShowLevelSelection);
            levelBackButton.onClick.AddListener(ShowMainMenu);
        }
        
        private void OnDisable() {
            levelButton.onClick.RemoveListener(ShowLevelSelection);
            levelBackButton.onClick.RemoveListener(ShowMainMenu);
        }
        
        private void ShowLevelSelection() {
            mainMenuScreen.SetActive(false);
            levelSelectionScreen.SetActive(true);
        }
        
        private void ShowMainMenu() {
            levelSelectionScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }
}