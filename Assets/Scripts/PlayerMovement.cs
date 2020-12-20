﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class PlayerMovement : MonoBehaviour
{
    public bool isActive;
    public Rigidbody playerRigidbody;
    private BoxCollider playerCollider;
    public float jumpSpeed;
    public float runSpeed;
    public float moveDirection;
    public bool isPulling;

    private void Awake()
    {
        isPulling = false;
        playerCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        Move(moveDirection);

        if (Input.GetKeyDown(KeyCode.W)) {
            Jump();
        }
    }

    private void Jump() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.1f))
        {
            playerRigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void Move(float dir)
    {
        if(isPulling == false) 
        {
            if (dir < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (dir > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
        playerRigidbody.velocity = new Vector3(runSpeed * dir, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
    }

}
