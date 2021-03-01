using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DepthMine : MonoBehaviour
{
    private float floatingSpeed = 2f;
    private float actualHeight;
    private float floatingModifier = 0.02f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectPooler.Instance.SpawnFromPool("MineExplosion", transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        actualHeight = transform.position.y;
        transform.position = new Vector3(transform.position.x, actualHeight + floatingModifier * Mathf.Sin(floatingSpeed * Time.time), transform.position.z);
        transform.Rotate(Vector3.up,0.5f);
    }
}
