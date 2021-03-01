using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputName;

    [SerializeField]
    private GameObject warning; 
    
    void Start()
    {
        inputName.characterLimit = 10;
    }


    public void StartGame()
    {
        if (!string.IsNullOrEmpty(inputName.text) && !string.IsNullOrWhiteSpace(inputName.text))
        {
            GameManager.PlayerName = inputName.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            warning.SetActive(true);
        }
    }
}
