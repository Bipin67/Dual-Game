using UnityEngine;

namespace Assets.Scripts.Enemy
{
   public class Enemy : MonoBehaviour
   {
      void Start()
      {
         
      }

      void OnTriggerEnter2D(Collider2D col)
      {
         //If the tag named bullet hits the enemy then the message will popped.
         if (col.transform.tag =="Bullet")
         {
            Debug.Log("The Enemy is hited.");
            Destroy(gameObject);
         }
      }
   }
}
