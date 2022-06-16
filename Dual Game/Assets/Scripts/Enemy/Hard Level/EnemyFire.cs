using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyFire : MonoBehaviour
    {
        //Private Instances
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _bulletFirePoint;
        private float _fireRate;
        private float _nextFire;
        private Transform _player;

        //Public Instances
        public float ShootingRange;
        /// <summary>
        ///Assigning the variable values.
        ///Assigning the value of _player i.e finding the game object with tag '"Player" and assign 
        /// </summary>
        void Start()
        {
            _fireRate = 1f;
            _nextFire = Time.time;
            //Assigning the _player value i.e. the _player is the player. 
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        
        void Update()
        {
            float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);
            if (distanceFromPlayer > ShootingRange ) ;
            {
                CheckTimeToFire();
            }
        }

        void CheckTimeToFire()
        {
            if (Time.time > _nextFire)
            {
                Vector3 newPosForBullet = new Vector3(_bulletFirePoint.transform.position.x,_bulletFirePoint.transform.position.y, -100);
                Instantiate(_bullet, newPosForBullet, Quaternion.identity);
                _nextFire = Time.time + _fireRate;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ShootingRange);
        }
    }
}