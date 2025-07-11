using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Scene.Player {
    public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        public bool isPressed;

        public void OnPointerDown(PointerEventData eventData) {
            isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData) {
            isPressed = false;
        }
    }
}