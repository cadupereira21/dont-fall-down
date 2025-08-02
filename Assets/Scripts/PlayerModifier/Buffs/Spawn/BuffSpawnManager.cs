using ObjectPooling;

namespace PlayerModifier.Buffs.Spawn {  
    public class BuffSpawnManager : SpawnManager {
        
        private void Start() {
            this.InvokeRepeating(nameof(InstantiatePowerUp), 4, 8);
        }

        private void InstantiatePowerUp() {
            this.SpawnObject(this.GetSpawnPosition());
        }
    }
}