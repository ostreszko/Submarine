using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightsHolder : MonoBehaviour
{
    [SerializeField]
    private Light spotLight;
    
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float addSpotAngleSpeed;

    [SerializeField]
    private float maxAngle = 70f;
    
    void Update()
    {
        spotLight.transform.position =
            new Vector3(playerTransform.position.x, playerTransform.position.y, spotLight.transform.position.z);

        if (spotLight.spotAngle < maxAngle)
        {
            spotLight.spotAngle += addSpotAngleSpeed * Time.deltaTime; 
        }



    }
}
