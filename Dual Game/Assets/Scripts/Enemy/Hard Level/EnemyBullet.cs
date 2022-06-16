using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
      //Assigning the rigidbody 2d .
      _bulletRb = GetComponent<Rigidbody2D>();
      //Assigning the _target value i.e. target is player..
      _target = GameObject.FindGameObjectWithTag("Player");
      //Calculating the _target position.
      Vector2 moveDir = (_target.transform.position - transform.position).normalized * speed;
      //Moving the bullet towards the position of the player
      _bulletRb.velocity = new Vector2(moveDir.x, moveDir.y);
      //Destroy the bullet after 3 seconds.
      Destroy(this.gameObject, 3f);
   }
}
