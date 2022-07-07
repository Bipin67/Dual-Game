using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
   //Instances
   public AudioClip BulletHitted;

   /// <summary>
   /// At start current health and max health value are equal.
   /// Max health of health bar is set ro MaxHealth.
   /// </summary>
   void Start()
   {
      CurrentHealth=MaxHealth ;
      HealthBar.SetMaxHealth(MaxHealth);
      _fireRate = 2f;
      _nextFireTime = Time.time;
   }

   /// <summary>
   /// Enemy patrol method called to move enemy from left to right and vice versa.
   /// </summary>
   void Update()
   {
      EnemyPatrol();
      FireEnemyBullet();
   }

   /// <summary>
   /// If enemy his hit by the player bullet game object then:
   /// -Bullet sounds will be played.
   /// -Enemy will take damage of 25 per hit.
   /// -And if the current health is 0 then enemy will be dead.
   /// </summary>
   /// <param name="coll"></param>
   void OnCollisionEnter2D(Collision2D coll)
   {
         if (coll.gameObject.tag == "Bullet")
      {
         Debug.Log("Enemy Collided with bullet Collider.");
         //Playing Bullet hit Sounds
         Audio_Manager.Instance.PlaySfx(BulletHitted);
         //Taking damage from bullets
         Damages.Instance.TakeDamage(40);
         //If enemy Current health is zero than destroy game object
         if (Damages.Instance.CurrentHealth <= 0)
         {
            Debug.Log("Enemy Current Health" +""+ CurrentHealth);
            Destroy(this.gameObject);
            Debug.Log("Enemy destroyed");
         }
         //Play Animation and Destroy theEnemy.
      }
   }

   /// <summary>
   /// Regions for Enemy patrol only. Here enemy moves from lefts to right and vice versa.
   /// </summary>
   #region Enemy Patrol
   
   //Instances usd for the Enemy Patrol
   public float Speed;
   public float Distance;
   private bool _moveRight;
   public Transform GroundCheckout;
   
   /// <summary>
   /// Enemy Moves left and Right using the ray cast method..
   /// </summary>
   void EnemyPatrol()
   {
      //Moving the position of the enemy towards right direction.      
      transform.Translate(Vector2.right * Speed * Time.deltaTime);
      //Using ray cast to hit the rays in the under the ground direction bout Distance length. 
      RaycastHit2D groundInfo = Physics2D.Raycast(GroundCheckout.position, Vector2.down, Distance);
      //Rotating the player when reaches the end point of the ground.
      if (groundInfo.collider == false)
      {
         //If move right is true the rotating the player towards -180 direction  following the disable of the move right .
         if (_moveRight)
         {
            transform.eulerAngles = new Vector3(0, -180, 0);
            _moveRight = false;
         }
            
         //Else setting the  rotation to 0 and enabling the move direction to true.  
         else
         {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _moveRight = true;
         }
      }
   }
   
   #endregion

   /// <summary>
   /// Region to change the health bar value of the enemy. 
   /// </summary>
   #region Health Bar

   //Public Instances used for Health bar
   public int MaxHealth=100;
   public int CurrentHealth;
   public Enemy_HealthBar HealthBar;

   /// <summary>
   /// Updating current health value in the health bar.
   /// </summary>
   /// <param name="damage"></param>
   void TakeDamage(int damage)
   {
      CurrentHealth -= damage;
      HealthBar.SetHealth(CurrentHealth);
   }
   #endregion

   /// <summary>
   /// Region to fire bullet from enemy.
   /// </summary>
   #region EnemyBulletFire
   //Instance used for Enemy bullet fire.
   public GameObject EnemyBullet;
   public Transform EnemyBulletFirePosition;
   public int EnemyBulletSpeed;
   
   //Private Instances
   private float _fireRate;
   private float _nextFireTime;
   
   /// <summary>
   /// Enemy instantiates the enemy bullet.
   /// Enemy bullet parent is set to its fire position.
   /// Giving the velocity to the enemy bullet.
   /// </summary>
   public void FireEnemyBullet()
   {
         if (Time.time > _nextFireTime)
         {
            //Instantiating th enemy bullets from enemy bullet fire position without any rotation.
            GameObject fireEnemyBullet = Instantiate(EnemyBullet, EnemyBulletFirePosition.position, Quaternion.identity);
            //Setting parent to instantiated enemy bullet.
            fireEnemyBullet.transform.SetParent(EnemyBulletFirePosition);
            //Applying force to the rigid body 2d of the enemy bullet.
            fireEnemyBullet.GetComponent<Rigidbody2D>().velocity = EnemyBulletFirePosition.up * EnemyBulletSpeed;
            _nextFireTime = Time.time + _fireRate;
         }
   }

   #endregion
}
