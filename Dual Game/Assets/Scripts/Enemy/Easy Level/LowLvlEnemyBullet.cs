using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowLvlEnemyBullet : MonoBehaviour
{
   //Private Instances
   private GameObject _target;
   public float speed;
   private Rigidbody2D _bulletRb;


   /// <summary>
   /// Find a player and throw the bullets towards the position of the player.
   /// Also destroy the bullets after 3 seconds.
   /// </summary>
   void Start()
   {
      //Assigning the rigid-body 2d .
      _bulletRb = GetComponent<Rigidbody2D>();
      
   //Moving the bullet towards the position of the player
     _bulletRb.velocity = new Vector2(transform.position.x, transform.position.y * speed);
      
      //Destroy the bullet after 3 seconds.
      Destroy(this.gameObject, 3f);
   }
}
