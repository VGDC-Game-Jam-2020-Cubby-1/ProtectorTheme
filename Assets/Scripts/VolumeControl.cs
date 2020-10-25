using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f,1f)]
    public float vol = 0.50f;
    void Start()
    {
        AudioListener.volume = vol;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = vol;
    }
}
