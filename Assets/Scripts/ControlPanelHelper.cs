using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelHelper : MonoBehaviour
{
    public static ControlPanelHelper Instance;
    
    [SerializeField]
    private int resWidth = 1920; 
    
    [SerializeField]
    private int resHeight = 1080;
    
    [SerializeField]
    private Button screenshotButton;

    [SerializeField]
    private Camera camera;

    private string folder;
    
    public string ScreenShotName(int width, int height) {
        return string.Format(folder + "/screen_{0}x{1}_{2}.png",
            width, height, 
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    private void Awake()
    {
        Instance = this;
        folder = $"{Application.dataPath}/screenshots";
    }

    private void OnEnable()
    {
        GameManager.SharedInstance.GameEnded += SharedInstanceOnGameEnded;
    }

    private void SharedInstanceOnGameEnded(bool won)
    {
        
    }

    public void CoinReached(bool reached)
    {
        screenshotButton.interactable = reached;
    }

    public void ScreenshotButtonClick()
    {
        TakeScreenshot();
        AudioManager.Instance.Play("Photo");
        GameManager.SharedInstance.EndGame(true);
    }
    
    private void TakeScreenshot()
    {
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);
        
        if (!System.IO.Directory.Exists(folder))
        {
            System.IO.Directory.CreateDirectory(folder);
        }
        
        System.IO.File.WriteAllBytes(filename, bytes);
    }
}
