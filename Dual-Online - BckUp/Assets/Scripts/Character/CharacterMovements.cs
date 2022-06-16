using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    //Public instances
    public float Speed;

    /// <summary>
    /// Calling a method to give the input in game.
    /// </summary>
    void Update()
    {
        //// Methods Calling
        //Gyroscope Control method calling. 
        AccelerationInputs();
    }
    
    /// <summary>
    /// Moving player towards x and y direction using the gyroscope input.
    /// </summary>
    void AccelerationInputs()
    {
        ////taking inputs for gyroscope.
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
            
        ////moving characters according to inputs.
        //moving players to wards x direction.
        transform.Translate(x * Speed* Time.deltaTime,0,0);
        //moving player towards y direction. 
        transform.Translate(0,y * Speed * 2f * Time.deltaTime,0);
    }
}

