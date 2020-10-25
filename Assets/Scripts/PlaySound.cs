using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float volume;

    AudioSource audioSrc;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void PlaySoundFX()
    {
        audioSrc.Play();
    }
}
