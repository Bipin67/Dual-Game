using UnityEngine;

namespace Assets.Scripts.Enemy.MEdiumLevel
{
    public class MediumLvlEnemyFire : MonoBehaviour
    {
        //Private Instances
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _bulletFirePoint;
        private float _fireRate;
        private float _nextFire;
        public Transform _player;

        //Public Instances
        public float ShootingRange;
        public float LineOfSite;
        public float Speed;
        
        /// <summary>
        ///Assigning the variable values.
        ///Assigning the value of _player i.e finding the game object with tag '"Player" and assign 
        /// </summary>
        void Start()
        {
            _fireRate = 2f;
            _nextFire = Time.time;
          
        }

          
        void Update()
        {
            //Assigning the _player value i.e. the _player is the player. 
         _player = GameObject.FindGameObjectWithTag("Bullet").transform;
            
            float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);
            if (distanceFromPlayer < LineOfSite && distanceFromPlayer > ShootingRange  ) ;
            {
                Vector2 xTarget = new Vector2(_player.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, xTarget, Speed * Time.deltaTime);
                
                // transform.position= Vector2.MoveTowards(this.transform.position, _player.position, Speed * Time.deltaTime);
            }
             if (distanceFromPlayer <= ShootingRange)
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
            Gizmos.DrawWireSphere(transform.position, LineOfSite);
        }
    }
}