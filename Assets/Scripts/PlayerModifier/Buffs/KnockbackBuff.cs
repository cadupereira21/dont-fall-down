using UnityEngine;

namespace PlayerModifier.Buffs {
    public class KnockbackBuff : Buff {
        
        [SerializeField] 
        [Range(5, 20)]
        private float knockbackStrength = 12;

        [SerializeField] 
        private PlayerModifierSo modifierSo;
        
        public float KnockbackStrength => knockbackStrength;
        
        private new void Start() {
            this.SpawnDuration = modifierSo.SpawnDuration;
            this.Duration = modifierSo.ModifierDuration;
            base.Start();
        }
    }
}