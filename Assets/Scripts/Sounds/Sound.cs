﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1f;

    [Range(0f, 1f)]
    public float pitch = 1f;

    public bool loop;
    
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
