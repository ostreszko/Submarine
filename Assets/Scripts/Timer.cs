using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeLabel;

    [SerializeField]
    private float oneGameTime;

    private float timeLeft;
    
    void Start()
    {
        timeLeft = oneGameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            timeLabel.text = ((int)timeLeft).ToString();
        }
    }

    public void DeplateTime(float amount)
    {
        float newTime = timeLeft - amount;
        timeLeft = Mathf.Max(newTime, 0f);
    }
}
