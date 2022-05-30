using UnityEngine;

namespace Assets.Scripts
{
    public class BulletFire : MonoBehaviour
    {
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
            GameObject firedBullet = Instantiate(bullet, _firepoint.position,_firepoint.rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = _firepoint.up * 10f;
        }
    }
}
