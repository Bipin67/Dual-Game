using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject,3);
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullets Collider Collided with Enemy Collider.");
            Destroy(gameObject);
        }
    }
}
