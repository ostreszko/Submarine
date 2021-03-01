using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreUIHelper : MonoBehaviour
{
    [SerializeField]
    private List<HighscorePlaceUIController> placesControllers;

    [SerializeField]
    private TextMeshProUGUI playerScoreText;
    
    private HighscoreData data;
    

    private void OnEnable()
    { 
        data = SaveHighscoreSystem.LoadHighscore();

        playerScoreText.text = Timer.Instance.TimePassed.ToString("0.00");

        if (data != null)
        {
            for (int i = 0; i < data.names.Length; i++)
            {
                if (!string.IsNullOrEmpty(data.names[i]))
                {
                    placesControllers[i].gameObject.SetActive(true);
                    placesControllers[i].SetTexts(data.names[i], data.times[i].ToString("0.00"));
                }
            }
        }
    }
}
