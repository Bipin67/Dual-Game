using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class BulletFire : MonoBehaviour
    {
        public AudioClip Fire;
        [SerializeField] private Transform _firepoint;
        [SerializeField] private GameObject bullet;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireBullet();
            }
        }

        public void FireBullet()
        {
            AudioManager.Instance.FireSound(Fire);
            GameObject firedBullet = Instantiate(bullet, _firepoint.position,_firepoint.rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = _firepoint.up * 10f;
        }
    }
}
