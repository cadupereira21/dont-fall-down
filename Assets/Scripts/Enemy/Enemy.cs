using ObjectPooling;
using UnityEngine;

namespace Enemy {
    public class Enemy : PooledObject {
        
        [SerializeField]
        [Range(150, 450)]
        private float enemySpeed = 300;
        
        private GameObject _player;

        private Rigidbody _enemyRb;

        public void Init(GameObject player, SpawnManager spawnManager, int indexAtPooler) {
            _player = player;
            base.Init(spawnManager, indexAtPooler);
        }

        private void Awake() {
            _enemyRb = this.GetComponent<Rigidbody>();
        }

        private void Update() {
            _enemyRb.AddForce((_player.transform.position - this.transform.position).normalized * (enemySpeed * Time.deltaTime),
                             ForceMode.Force);
            
            DespawnIfOutOfBounds();
        }
        
        private void DespawnIfOutOfBounds() {
            if (!(this.transform.position.y < -10)) return;
            
            this.transform.position.Set(0, 0, 0);
            this.Despawn();
        }
    }
}