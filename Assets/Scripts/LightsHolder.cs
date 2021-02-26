using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightsHolder : MonoBehaviour
{
    [SerializeField]
    private Transform spotLightTransform;
    
    [SerializeField]
    private Transform playerTransform;
    
    void Update()
    {
        spotLightTransform.position =
            new Vector3(playerTransform.position.x, playerTransform.position.y, spotLightTransform.position.z);
    }
}
