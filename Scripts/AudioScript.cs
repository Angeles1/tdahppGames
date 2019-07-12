using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    AudioSource audioSource;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        audioSource = GetComponent<AudioSource>();

    }

    public void MuteGame()
    {
        audioSource.mute = !audioSource.mute;

    }
}
