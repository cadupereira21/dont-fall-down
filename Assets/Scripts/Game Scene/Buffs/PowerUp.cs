using Game_Scene.ObjectPooling;
using UnityEngine;

namespace Game_Scene.Buffs {
    public abstract class PowerUp : PooledObject {
        private const string TAG_PLAYER = "Player";
        
        protected float Duration;

        protected float DestroyTimeInSeconds;
        public float GetDuration => Duration;

        protected void Start() {
            this.Invoke(nameof(this.Despawn), DestroyTimeInSeconds);
        }

        protected void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(TAG_PLAYER)) {
                this.Despawn();
            }       
        }
    }
}