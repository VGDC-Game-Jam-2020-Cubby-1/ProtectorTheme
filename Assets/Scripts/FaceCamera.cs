using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        var canvas = GetComponent<Canvas>();

        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }

        var pos = canvas.worldCamera.transform.position;
        transform.LookAt(transform.position - pos);
    }
}
