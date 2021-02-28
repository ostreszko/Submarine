using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBubblesController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    
    private void OnEnable()
    {
        particle.Play();
    }


    void Update()
    {
        if (!particle.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
