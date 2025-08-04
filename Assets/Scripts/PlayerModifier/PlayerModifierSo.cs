using UnityEngine;

namespace PlayerModifier {
    
    [CreateAssetMenu(fileName = "modifier", menuName = "Player Modifier")]
    public class PlayerModifierSo : ScriptableObject {

        public ModifierType ModifierType;

        [Tooltip("The duration in seconds the modifier will remain spawned in the world.")]
        public float SpawnDuration;
        
        [Tooltip("The duration in seconds the modifier will be active after being collected by the player.")]
        public float ModifierDuration;

    }
}