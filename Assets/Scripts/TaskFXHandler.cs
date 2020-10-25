using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFXHandler : MonoBehaviour
{
    public AudioClip[] fxToPlay;

    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayRandomFX()
    {
        int index = Random.Range(0, fxToPlay.Length);
        audioSrc.PlayOneShot(fxToPlay[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
