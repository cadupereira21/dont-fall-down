using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class EnemyController : PooledObject {
        private GameObject _player;

        private Rigidbody _enemyRb;

        public float enemySpeed;

        public void Init(GameObject player, ObjectPooler pooler, int indexAtPooler) {
            _player = player;
            base.Init(pooler, indexAtPooler);
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
                this._pooler.InactivateObject(_indexAtPooler);
            }
        }
    }
}