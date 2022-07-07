using System;
using System.Timers;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Timer = System.Threading.Timer;

namespace Assets.Scripts.Character
{
    public class CharacterBulletFire : MonoBehaviour
    {
        [Header("Fire Point")]
        [SerializeField] private Transform _firePoint;
        
        [Header("Game Objects")]
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject ReloadUi;
        // [SerializeField] private GameObject[] _ammos;
        [SerializeField] private GameObject _bigBullet;

        [Header("Server Side")]
        private PhotonView _view;
        
        [Header("Integers")]
        [SerializeField]private int _ammoAmount;
        public float BulletSpeed;
        public float TimerValue;

        [Header("Audios")]
        public AudioClip FireBulletSound;
        
        [Header("Boolean Values")]
        public bool IsClicked=true;

        [Header("Text Values")] 
        public Text TimerText;
        public Text AmmoText;
        
        /// <summary>
        /// Disabling all the images of the array.
        /// Setting default ammo size to 0.
        /// </summary>
        void Start()
        {
            IsClicked = true;
            _view = GetComponent<PhotonView>();

            //Setting Default ammo amount value to 0
            _ammoAmount = 0;
            AmmoText.text = _ammoAmount.ToString();
        }

        void Update()
        {
            //If Ammo is zero then showing the Reload Button.
            if (_ammoAmount <= 3)
            {
                ReloadUi.gameObject.SetActive(true);
            }
            //If timer value is greater than 0 then decreasing the timer value according to the current time.
            if (TimerValue > 0)
            {
                TimerValue -= Time.deltaTime;
            }
            //Else Timer value will be 0 if  timer value is not greater than 0.
            else
            {
                TimerValue = 0;
            }
            //Disabling the isClicked value to fire a bigger bullet.
            if (TimerValue == 0)
            {
                IsClicked = false;
            }
            //Calling Method with TimerValue Parameter.
            TimeToDisplay(TimerValue);
        }

        /// <summary>
        /// It displays the tim ein the timer text field.
        /// </summary>
        /// <param name="timeToDisplay"></param>
        void TimeToDisplay(float timeToDisplay)
        {
            if (timeToDisplay<0)
            {
                timeToDisplay = 0;
            }
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            TimerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
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
            AmmoText.text = _ammoAmount.ToString();
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
                //Bullets will be fire if the ammo amount is greater than 0 and if the IsClicked  is true.
                if (_ammoAmount > 0 && IsClicked == true)
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
                    AmmoText.text = _ammoAmount.ToString();
                }
        }

        public void LongPressBullet()
        {
            //Bullets will be fire if the ammo amount is greater than 0 and if the IsClicked  is true.
            if (_ammoAmount > 0 && IsClicked == false)
            {
                //Playing Bullet Fire Sound from Audio_Manager.
                Audio_Manager.Instance.PlaySfx(FireBulletSound);
                //Instantiating the bullet from fire-point.
                GameObject firedBullet = Instantiate(_bigBullet, _firePoint.position, quaternion.identity);
                //Setting parent to the instantiated bullet.
                firedBullet.transform.SetParent(_firePoint);
                //Setting position of the instantiated bullet in parent _firepoint to zero 
                firedBullet.transform.localPosition = Vector3.zero;
                //Giving direction and the speed to the instantiated bullet.
                firedBullet.GetComponent<Rigidbody2D>().velocity = _firePoint.up * BulletSpeed;
                //Decreasing the ammo value by 1 each fire
                _ammoAmount -= 1;
                AmmoText.text = _ammoAmount.ToString();
                //Resetting the timer value
                TimerValue=10;
                IsClicked = true;
            }
        }
    }
}