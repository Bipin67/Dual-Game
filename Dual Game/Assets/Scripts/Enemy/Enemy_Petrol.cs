using System.IO;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy_Petrol : MonoBehaviour
    {
        //Instances
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            //if the enemy is facing towards right then it will move towards the right direction with the speed of _moveSpeed.
            bool isFacingRight = IsFacingRight();
            if (isFacingRight)
            {
                _rb.velocity = new Vector2(_moveSpeed, 0f);
            }
            else //else the enemy will move towards the left direction with the speed of _moveSpeed.
            {
                _rb.velocity = new Vector2(-_moveSpeed, 0f);
            }
        }

        private bool IsFacingRight()
        {
            //Epsilon is very very low value ==0.0001
            return transform.localScale.x > Mathf.Epsilon;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // On hitting the collider it will change the x position.
            if (collision.transform.tag != "Stopper") return;
            transform.localScale = new Vector2(-(Mathf.Sign(_rb.velocity.x)), transform.localScale.y);
            Debug.Log("Enemy is collided.");
        }
    
        void OnTriggerEnter2D(Collider2D col)
        {
            //If the tag named bullet hits the enemy then the message will popped.
            if (col.transform.tag == "Bullet")
            {
                Debug.Log("The Enemy is hited during enemy petrol.");
                Destroy(gameObject);
            }
        }
    }
}