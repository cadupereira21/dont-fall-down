using UnityEngine;
using UnityEngine.Serialization;

namespace Game_Scene.Buffs {
    public class KnockbackPowerUp : PowerUp {
        [FormerlySerializedAs("knockBackStrength")] [SerializeField] private float getKnockBackStrength;

        public float GetKnockBackStrength => this.getKnockBackStrength;
        
        private new void Start() {
            this.DestroyTimeInSeconds = 15.0f;
            this.Duration = 5.0f;
            base.Start();
        }
    }
}