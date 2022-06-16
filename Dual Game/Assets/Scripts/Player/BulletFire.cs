using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class BulletFire : MonoBehaviour
    {
        // public AudioClip Fire;
        [SerializeField] private Transform _firepoint;
        [SerializeField] private GameObject bullet;
        private float _bulletSpeed = 10f;

        private float _fireRate;
        private float _nextFireTime;


        void Start()
        {
            _fireRate = 3f;
            _nextFireTime = Time.time;
        }

        void Update()
        {
                FireBullet();
        }

        public void FireBullet()
        {
            if (Time.time > _nextFireTime)
            {
                // AudioManager.Instance.FireSound(Fire);
                GameObject firedBullet = Instantiate(bullet, _firepoint.position,_firepoint.rotation);
                firedBullet.GetComponent<Rigidbody2D>().velocity = _firepoint.up * _bulletSpeed;
                _nextFireTime = Time.time + _fireRate;
            }
            
        }
    }
}
