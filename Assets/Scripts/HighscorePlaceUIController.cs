using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscorePlaceUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    
    [SerializeField]
    private TextMeshProUGUI timeText;

    public void SetTexts(string name, string time)
    {
        nameText.text = name;
        timeText.text = time;
    }
}
