using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterMovements : MonoBehaviour
    {
        //Public instances
        public float Speed = 10f;
        public  Transform BulletSpawnPoint;
        public GameObject BulletPrefab;
        public float BulletSpeed = 30f;
        
        void Start()
        {
            
        }

        void Update()
        {
            //// Methods Calling
            //Gyroscope Control method calling. 
            AccelerationInputs();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.up * BulletSpeed;
            }



        }

        public void AccelerationInputs()
        {
            ////taking inputs for gyroscope.
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            
            ////moving characters according to inputs.
            //moving players to wards x direction.
            transform.Translate(x * Speed* Time.deltaTime,0,0);
            //moving player towards y direction. 
            transform.Translate(0,y * Speed * 1.2f * Time.deltaTime,0);
        }
    }
}
