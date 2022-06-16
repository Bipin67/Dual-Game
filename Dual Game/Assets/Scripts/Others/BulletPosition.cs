using UnityEngine;

namespace Assets.Scripts.Others
{
    public class BulletPosition : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "PlayerBullet")
            {
                float xPos = transform.position.x;
                Debug.Log("harp" + xPos);
            }
        }
    }
}
