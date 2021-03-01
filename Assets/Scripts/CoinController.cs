using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;
    
    [SerializeField]
    private Vector3 scaleUpModifier;
    
   
    private Vector3 normalScaleModifier;

    private bool scaleUp = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ControlPanelHelper.Instance.CoinReached(true);
            AudioManager.Instance.Play("Coin");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ControlPanelHelper.Instance.CoinReached(false); 
        }
    }

    private void Start()
    {
        normalScaleModifier = transform.localScale;
    }

    private void OnEnable()
    {
        StartCoroutine(ScaleCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ScaleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,rotationSpeed);
        
    }

    IEnumerator ScaleCoroutine()
    {
        yield return transform.DOScale(scaleUp ? scaleUpModifier : normalScaleModifier, 1f).WaitForCompletion();
        scaleUp = !scaleUp;

        StartCoroutine(ScaleCoroutine());
    }
}
