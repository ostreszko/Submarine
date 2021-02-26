using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubmarineController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody submarineRb;

    [SerializeField] 
    private float submarineSpeed;

    [SerializeField] 
    private GameObject propellor;
    
    [SerializeField] 
    private float propellorRotationSpeed;

    private float velocityX;
    private float velocityY;
    private float velocityZ;

    private float horizontalAxis;
    
    private Vector3 leftRotation = new Vector3(0, 0, 0);
    private Vector3 rightRotation = new Vector3(0, -180, 0);
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        if (horizontalAxis != 0)
        {
            submarineRb.AddForce(Vector3.right * (horizontalAxis * Time.deltaTime), ForceMode.Impulse);
            submarineRb.AddForce(Vector3.up * (Input.GetAxis("Vertical") * Time.deltaTime), ForceMode.Impulse);
            RotateToMovingDirection();
        }
        
        ReduceVelocity();
    }

    private void RotateToMovingDirection()
    {
        if (horizontalAxis > 0f)
        {
            submarineRb.DORotate(rightRotation, 1f, RotateMode.Fast);
        }
        else if (horizontalAxis < 0f)
        {
            submarineRb.DORotate(leftRotation, 1f, RotateMode.Fast);
        }
        
        propellor.transform.Rotate(Vector3.forward * (Time.deltaTime * propellorRotationSpeed * Mathf.Abs(horizontalAxis))
            ,Space.Self);
    }
    
    private void ReduceVelocity()
    {
        submarineRb.velocity = new Vector3(
            submarineRb.velocity.x * 0.99f,
            submarineRb.velocity.y * 0.96f,
            submarineRb.velocity.z);
    }
}
