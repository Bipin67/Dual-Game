using UnityEngine;

namespace Assets.Scripts.Others
{
    public class BulletDestroy : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject,3f);
        }
    }
}
