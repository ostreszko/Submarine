using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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

    [SerializeField]
    private ParticleSystem proppelorBubbles;
    
    [SerializeField]
    private ParticleSystem ventTubesBubbles;

    [SerializeField]
    private List<Renderer> renderers;
    
    [SerializeField]
    private Timer timer;

    private float velocityX;
    private float velocityY;
    private float velocityZ;

    private bool isPowerOn = false;
    private bool isSpeedUp = false;
    private bool isGoUp = false;
    private bool isGoDown = false;

    private bool isInvincible = false;
    
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInvincible && other.CompareTag("Fish"))
        {
            timer.DeplateTime(10f);
            StartCoroutine(BoatHit());

        }
        
        if (other.CompareTag("Mine"))
        {
            timer.DeplateTime(20f);
        }
    }

    void FixedUpdate()
    {
        if (isPowerOn)
        {
            if (isSpeedUp)
            {
                submarineRb.AddForce(-transform.right * (submarineSpeed * Time.deltaTime), ForceMode.Impulse);

                
                if (!proppelorBubbles.isPlaying)
                {
                    proppelorBubbles.Play();
                }
                
            }else if (proppelorBubbles.isPlaying)
            {
                proppelorBubbles.Stop();
            }

            if (isGoDown)
            {
                submarineRb.AddForce(Vector3.down * (submarineSpeed * Time.deltaTime), ForceMode.Impulse);
                
                if (!ventTubesBubbles.isPlaying)
                {
                    ventTubesBubbles.Play();
                }
            }else if (ventTubesBubbles.isPlaying)
            {
                ventTubesBubbles.Stop();
            }

            if (isGoUp)
            {
                submarineRb.AddForce(Vector3.up * (submarineSpeed * Time.deltaTime), ForceMode.Impulse);
            }
            

        }
        
        propellor.transform.Rotate(Vector3.forward *
                                   (Time.deltaTime * propellorRotationSpeed * (Convert.ToInt32(isPowerOn) + Convert.ToInt32(isSpeedUp)))
            ,Space.Self);
        ReduceVelocity();
    }

    public void RotateSubmarine()
    {
        submarineRb.DORotate(new Vector3(0, transform.localEulerAngles.y + 180f, 0), 1f, RotateMode.Fast);
    }
    
    public void PowerOn()
    {
        isPowerOn = !isPowerOn;
        isSpeedUp = false;
        isGoDown = false;
        isGoUp = false;

    }

    public void SpeedUp()
    {
        isSpeedUp = !isSpeedUp;
    }
    
    public void GoDown()
    {
        isGoDown = !isGoDown;
        isGoUp = false;
    }
    
    public void GoUp()
    {
        isGoUp = !isGoUp;
        isGoDown = false;
    }

    private void ReduceVelocity()
    {
        submarineRb.velocity = new Vector3(
            submarineRb.velocity.x * 0.99f,
            submarineRb.velocity.y * 0.96f,
            submarineRb.velocity.z);
    }
    
    

    IEnumerator BoatHit()
    {
        ObjectPooler.Instance.SpawnFromPool("HitBubbles", transform.position, transform.rotation);
        isInvincible = true;
        yield return StartCoroutine(SetTransparency(0.2f));
        isInvincible = false;

    }

    IEnumerator SetTransparency(float time)
    {
        bool fade = true;
        
        for (int i = 0; i < 12; i++)
        {
            foreach (var VARIABLE in renderers)
            {
                foreach (var VARIABLE2 in VARIABLE.materials)
                {
                    VARIABLE2.DOFade(fade ? 0.2f : 1f, time);
                }
            }

            fade = !fade;
            
            yield return new WaitForSeconds(time);
        }

    }
}
