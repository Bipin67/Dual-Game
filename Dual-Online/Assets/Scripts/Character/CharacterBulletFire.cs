using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterBulletFire : MonoBehaviour
    {
        //Private Instances
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject[] _ammos;
        [SerializeField] private GameObject ReloadUi;

        private int _ammoAmount;

        //Public Instances
        public float BulletSpeed;
        public AudioClip FireBulletSound;

        /// <summary>
        /// Disabling all the images of the array.
        /// Setting default ammo size to 0.
        /// </summary>
        void Start()
        {
            //Disabling the images of the ammo in the array.
            for (int i = 0; i <= 5; i++)
            {
                _ammos[i].gameObject.SetActive(false);
            }

            //Setting Default ammo amount value to 0
            _ammoAmount = 0;
        }

        /// <summary>
        /// Sets ammo amount to 6,
        /// shows all the images of the array,
        /// reload button will be disabled. 
        /// </summary>
        public void ReloadBullets()
        {
            Debug.Log("Bullets are reloaded");
            //Setting ammo amount to 6.
            _ammoAmount = 6;
            //showing images of bullets of the arrays
            for (int i = 0; i <= 5; i++)
            {
                _ammos[i].gameObject.SetActive(true);
            }

            //Disabling the reloadUi game object. 
            ReloadUi.gameObject.SetActive(false);
        }

        /// <summary>
        /// If  ammo  amount is greater than 0 then _bullet prefab will be instantiate from _firePoint with speed(BulletSpeed ) at upward direction.
        /// Ammo amount will decreased 1/1.
        /// Bullet images will be disabled form the array.
        /// </summary>
        public void FireBullet()
        {
            if (_ammoAmount > 0)
            {
                //Playing Bullet Fire Sound from Audio_Manager.
                Audio_Manager.Instance.PlaySfx(FireBulletSound);
                //Instantiating the bullet from fire-point.
                GameObject firedBullet = Instantiate(_bullet, _firePoint.position, quaternion.identity);
                firedBullet.transform.SetParent(_firePoint);
                firedBullet.transform.localPosition = Vector3.zero;
                //Giving direction and the speed to the instantiated bullet.
                firedBullet.GetComponent<Rigidbody2D>().velocity = _firePoint.up * BulletSpeed;
                //Decreasing the ammo value by 1 each fire
                _ammoAmount -= 1;
                //Disabling the image of decreased ammo value.
                _ammos[_ammoAmount].gameObject.SetActive(false);
            }

            //If Ammo is zero then showing the Reload Button.
            if (_ammoAmount == 0)
            {
                ReloadUi.gameObject.SetActive(true);
            }
        }
    }
}