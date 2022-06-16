using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterMovements : MonoBehaviour
{
    //Public instances
    public float Speed;
    private PhotonView view;
    private Rigidbody2D _rb;
    private float _moveX;
    private float _moveY;

    void Start()
    {
        view = GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>Calling a method to give the input in game.</summary>
    void Update()
    {
        if (view.IsMine)
        {
            AccelerationInputs();
        }
    }

    /// <summary>Taking Acceleration inputs for the gyroscope movements of the player. Fixing the X  & Y movements of the player</summary>
    public void AccelerationInputs()
    {
        //Taking acceleration inputs 
        _moveX = Input.acceleration.x* Speed;
        _moveY = Input.acceleration.y * Speed;
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), Mathf.Clamp(transform.position.y,-4f,4f));
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveX, _moveY);
    }
}

