using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public event Action<bool> GameEnded;
    
    private Button screenshotButton;

    public bool GameRunning = true;
    
    public static string PlayerName { get; set; }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this; 
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
    }

    private void Start()
    {
        AudioManager.Instance.Play("ThemeMusic");
    }

    private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        GameRunning = true;
    }

    public void EndGame(bool won)
    {
        Time.timeScale = 0f;
        GameRunning = false;
        
        GameEnded?.Invoke(won);
    }
}
