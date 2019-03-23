/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
}
