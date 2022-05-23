using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float Life = 3;

   void Awake()
   {
      Destroy(gameObject, Life);
   }

   void OnCOllisionEnter2d(Collider2D collision)
   {
      Destroy(collision.gameObject);
      Destroy(gameObject);
   }
}
