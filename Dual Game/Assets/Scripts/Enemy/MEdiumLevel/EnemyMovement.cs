using Assets.Scripts.Others;
using UnityEngine;

namespace Assets.Scripts.Enemy.MEdiumLevel
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed;
        public Transform Target;
    
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _bulletFirePoint;
        private float _nextFire;
        public float FireRate;
    
        //Test
        public GameObject Bullet;
        
        
        void Start()
        {
            _nextFire = Time.time;
            Target = GameObject.FindGameObjectWithTag("Bullet").transform;
        }

        void Update()
        {
            //If target position is greater then 0.5 it  the enemy will move towards the x direction of the   Bullet.
            if(Vector2.Distance(transform.position, Target.position) > 0.5) MoveTowardsXDirection();
            if (Time.time > _nextFire) InstantiateBullet();
        }
    
        /// <summary>
        /// Instantiate bullet from the _bulletFirePoint position.
        /// </summary>
        void InstantiateBullet()
        {
            //Setting new z position of the bullet with same x & y position of bullet as the _bulletFirePoint.
            Vector3 newPosForBullet = new Vector3(_bulletFirePoint.transform.position.x,_bulletFirePoint.transform.position.y, -100);
            Instantiate(_bullet, newPosForBullet, Quaternion.identity);
            //Adding fire time with current time.
            _nextFire = Time.time + FireRate;
        }

        /// <summary>
        /// Setting new target position and moving towards the x position of  target  with moveSpeed.
        /// </summary>
        void MoveTowardsXDirection()
        {
            // Moving towards the x direction of the bullet
            Vector2 xTarget = new Vector2(Target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, xTarget, moveSpeed * Time.deltaTime);
        }

        // void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.transform.tag == "Bullet")
        //     {
        //         // Debug.Log("The enemy is hit with the bullet fired from player.");
        //         Destroy(gameObject);
        //     }
        // }
        // void OnCollisionEnter2D(Collision2D ot)
        // {
        //     if (ot.gameObject.tag == "Bullet")
        //     {
        //         Debug.Log("The enemy is hit with the bullet fired from player.");
        //     }
        // }


    }
}
