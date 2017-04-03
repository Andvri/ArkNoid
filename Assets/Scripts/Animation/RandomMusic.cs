using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class RandomMusic : MonoBehaviour {
    public AudioClip clip1;
    public AudioClip clip2;
    private void Awake()
    {
        GetComponent<AudioSource>().clip = (Random.value>=0.5) ? clip1: clip2;
        GetComponent<AudioSource>().Play();
    }
    // Use this for initialization
    
}
