using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class LowLvlEnemyFire : MonoBehaviour
    {
        //Private Instances
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _bulletFirePoint;
        private float _fireRate;
        private float _nextFire;

        //Public Instances

        /// <summary>
        ///Assigning the variable values.
        ///Assigning the value of _player i.e finding the game object with tag '"Player" and assign 
        /// </summary>
        void Start()
        {
            _fireRate = 3f;
            _nextFire = Time.time;
            
            //Assigning the _player value i.e. the _player is the player. 
        }
        
        void Update()
        {
                CheckTimeToFire();
        }

        void CheckTimeToFire()
        {
            if (Time.time > _nextFire)
            {
              //   Vector3 newPosForBullet = new Vector3(_bulletFirePoint.transform.position.x,_bulletFirePoint.transform.position.y, -100);
              // Instantiate(_bullet, newPosForBullet, Quaternion.identity);
                _nextFire = Time.time + _fireRate;
            }
        }
    }
}