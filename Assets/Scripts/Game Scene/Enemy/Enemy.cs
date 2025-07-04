using Game_Scene.ObjectPooling;
using UnityEngine;

namespace Game_Scene.Enemy {
    public class Enemy : PooledObject {
        private GameObject _player;

        private Rigidbody _enemyRb;
        
        private int _indexAtPooler;

        public float enemySpeed;

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
            
            DestroyPlayerIfOutOfBounds();
        }
        
        private void DestroyPlayerIfOutOfBounds() {
            if (this.transform.position.y < -10) {
                this.SpawnManager.DespawnObject(_indexAtPooler);
            }
        }
    }
}