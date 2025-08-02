using Game_Scene.ObjectPooling;
using ObjectPooling;
using UnityEngine;

namespace PlayerModifier.Buffs {
    public abstract class Buff : PooledObject {
        
        private const string TAG_PLAYER = "Player";
        
        protected float Duration;

        protected float SpawnDuration;
        
        public float GetDuration => Duration;

        protected void Start() {
            this.Invoke(nameof(this.Despawn), SpawnDuration);
        }

        protected void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag(TAG_PLAYER)) {
                this.Despawn();
            }       
        }
    }
}