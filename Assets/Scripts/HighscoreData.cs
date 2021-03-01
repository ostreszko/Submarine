using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighscoreData
{
    public string[] names;
    public float[] times;

    public HighscoreData(string[] namesToSave, float[] timesToSave)
    {
        names = new string[3];
        times = new float[3];
        
        for (int i = 0; i < namesToSave.Length; i++)
        {
            names[i] = namesToSave[i];
        }
        
        for (int i = 0; i < timesToSave.Length; i++)
        {
            times[i] = timesToSave[i];
        }
    }
}
