using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    
    [SerializeField]
    private TextMeshProUGUI timeLabel;

    [SerializeField]
    private float oneGameTime;

    private float timeLeft;

    public float TimePassed => oneGameTime - timeLeft;


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded +=SceneManagerOnsceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
    }

    private void SceneManagerOnsceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if (scene.buildIndex == 1)
        {
            timeLeft = oneGameTime;
            Time.timeScale = 1f;
        }
    }

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
        else if(GameManager.SharedInstance.GameRunning)
        {
            GameManager.SharedInstance.EndGame(false);
        }
    }

    public void DeplateTime(float amount)
    {
        float newTime = timeLeft - amount;
        timeLeft = Mathf.Max(newTime, 0f);
    }
    
}
