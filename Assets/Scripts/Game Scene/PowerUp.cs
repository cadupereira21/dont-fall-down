using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Course_Library.Scripts {
    public abstract class PowerUp : MonoBehaviour {
        private const string TagPlayer = "Player";
        
        protected float Duration;

        protected float DestroyTimeInSeconds;
        public float GetDuration => Duration;

        protected void Start() {
            this.Invoke(nameof(DestroyPowerUp), DestroyTimeInSeconds);
        }

        protected void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(TagPlayer)) {
                Destroy(this.gameObject);
            }       
        }
        
        private void DestroyPowerUp() {
            Destroy(this.gameObject);
        }
    }
}