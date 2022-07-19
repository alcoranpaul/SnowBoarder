using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private bool crashDetected = false; 

    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueForce = 11;
    [SerializeField] float boostSpeed = 20;
    [SerializeField] float normalSpeed = 12;
    
    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!crashDetected)
        {
            PlayerControls();
            RespondToBoost();
        }
        
    }

    private void RespondToBoost()
    {
        Debug.Log("Boost are working!!");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void PlayerControls()
    {
        Debug.Log("Player Controlls are working!!");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddTorque(torqueForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddTorque(-torqueForce);
        }
    }

    public void StopPlayer()
    {
        crashDetected = true;
        torqueForce = 0;
        surfaceEffector2D.speed = 1;
        
    }
}
