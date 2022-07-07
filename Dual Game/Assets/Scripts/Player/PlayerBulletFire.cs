using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBulletFire : MonoBehaviour
    {
        public AudioClip Fire;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject[] _ammo;
        private float _bulletSpeed = 10f;
        private int _ammoAmount;
        public GameObject ReloadUi;
        
        /// <summary>
        /// Disabling all the images from the array.
        /// Setting ammo size to 0;
        /// </summary>
        void Start()
        {
            
            for (int i = 0; i<= 5; i++)
            {
                _ammo[i].gameObject.SetActive(false);
            }
            //Settings default ammo value to 0.
            _ammoAmount = 0;
        }
    
        /// <summary>
        /// Reload Function (If R keyword is pressed  then disabling the images from the array)
        /// Setting _ammoAmount to 6
        /// </summary>
        void Update()
        {
            //If  R key is pressed in the keyboard then the ammo size will be 6.
            //All the Images from the array are displayed.
            if (Input.GetKeyDown(KeyCode.R))
            {
               Reload();
            }
        }
    
        /// <summary>
        /// Sets default ammo size to 6 and shows all the images of the ammos in game.
        /// </summary>
        public void Reload()
        {
            
            _ammoAmount = 6;
            for (int i = 0; i <= 5; i++)
            {
                _ammo[i].gameObject.SetActive(true);
            }
            //Disabling Reload UI
            ReloadUi.SetActive(false);
        }

        /// <summary>
        /// Bullet will be fired if the key Space is pressed & ammoAmount is greater than 0.
        ///  Decreasing the ammoAmount by 1 per fire clicked and disabling the fired bullet image from the array.
        /// </summary>
         public void FireBullet()
        {
            //if teh ammo amount is greater than 0 than fire the bullet with sound  and decrease the ammo amount.
             if ( _ammoAmount>0)
             {
                 //Playing  the bullet fire sound.
                 AudioManager.Instance.FireSound(Fire);
                 
                 //Firing the _bullet from _firePoint with the speed of _bulletSpeed at up direction.
                 GameObject firedBullet = Instantiate(_bullet, _firePoint.position,_firePoint.rotation);
                 firedBullet.GetComponent<Rigidbody2D>().velocity = _firePoint.up * _bulletSpeed;
                 
                 //Decreasing the _ammoAmount by 1 per fire clicked.
                 _ammoAmount -= 1;
                 
                 //Disabling the fired bullet image.
                 _ammo[_ammoAmount].gameObject.SetActive(false);
             }
            
             //If ammo amount is decreased to 0 then Reload Ui will be shown. 
             if (_ammoAmount == 0)
             {
                 //Enabling  Reload UI
                 ReloadUi.SetActive(true);
             }
        }
        
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag =="Stopper")
            {
                Debug.Log("I am collided bullet");
            }
        }
    }
}
