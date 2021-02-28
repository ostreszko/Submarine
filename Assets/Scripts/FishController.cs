using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    
    [SerializeField]
    private float maxSpeed;
    
    [SerializeField]
    private float speed;

    private bool isRotating = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isRotating && other.CompareTag("Bounds"))
        {
            TouchedBounds();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isRotating && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * (speed * Time.deltaTime), ForceMode.Acceleration);
        }
    }

    private void TouchedBounds()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(-transform.forward * (speed * Time.deltaTime), ForceMode.VelocityChange);
        StartCoroutine(TurnBack());
    }

    IEnumerator TurnBack()
    {
        isRotating = true;
        yield return rb.DORotate(new Vector3(0, transform.localEulerAngles.y + 180f, 0), 1f, RotateMode.Fast).WaitForCompletion();
        isRotating = false;
    }
}
