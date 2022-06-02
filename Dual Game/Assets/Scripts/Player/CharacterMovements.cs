using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterMovements : MonoBehaviour
    {
        //Public instances
        public float Speed = 10f;
     
        void Update()
        {
            //// Methods Calling
            //Gyroscope Control method calling. 
            AccelerationInputs();
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
            transform.Translate(0,y * Speed * 1.5f * Time.deltaTime,0);
        }
    }
}
