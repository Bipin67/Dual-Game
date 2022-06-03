using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   private GameObject _target;
   public float speed;
   private Rigidbody2D _bulletRb;


   void Start()
   {
      _bulletRb = GetComponent<Rigidbody2D>();
      _target = GameObject.FindGameObjectWithTag("Player");
      Vector2 moveDir = (_target.transform.position - transform.position).normalized * speed;
      _bulletRb.velocity = new Vector2(moveDir.x, moveDir.y);
      Destroy(this.gameObject, 3f);
   }
}
