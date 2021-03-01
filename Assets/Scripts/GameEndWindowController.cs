using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndWindowController : MonoBehaviour
{
    [SerializeField]
    private GameObject highscoreObject;

    [SerializeField]
    private GameObject gameOverText;
    
    [SerializeField]
    private GameObject restartGameButton;
    

    // Start is called before the first frame update
    private void OnEnable()
    {
        GameManager.SharedInstance.GameEnded += SharedInstanceOnGameEnded;
    }

    private void OnDisable()
    {
        GameManager.SharedInstance.GameEnded -= SharedInstanceOnGameEnded;
    }


    private void SharedInstanceOnGameEnded(bool isGameWinned)
    {
        if (isGameWinned)
        {
            ManageScoreData();
            highscoreObject.SetActive(true);
        }else
        {
            gameOverText.SetActive(true);
        }
        
        restartGameButton.SetActive(true);
    }

    private void ManageScoreData()
    {
        float time = Timer.Instance.TimePassed;
        string playerName = GameManager.PlayerName;
        bool isEmptySlot = false;
        int emptySlot = 0;
        
        string tempName = "";
        float tempTime;
            
        HighscoreData data = SaveHighscoreSystem.LoadHighscore();
        if (data != null)
        {
            
            for (int i = 0; i < data.times.Length; i++)
            {
                if (data.times[i] == 0f || data.times[i] > time)
                {
                    tempName = data.names[i];
                    tempTime = data.times[i];
                    
                    data.names[i] = playerName;
                    data.times[i] = time;

                    playerName = tempName;
                    time = tempTime;
                } 
            }
        }
        else
        {
            data = new HighscoreData(new string[] {playerName}, new float[] {time});
        }
            
        SaveHighscoreSystem.SaveHighscore(data.names, data.times);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}
