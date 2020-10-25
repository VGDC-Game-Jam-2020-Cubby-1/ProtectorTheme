using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSide : MonoBehaviour
{
    private Animator animator;
    const string ANIMATOR_ISOPEN = "IsOpen";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetOpen(bool isOpen)
    {
        // Debug.LogFormat("Set {0}", isOpen);
        animator.SetBool(ANIMATOR_ISOPEN, isOpen);
    }

    // void Update()
    // {
    //     Debug.Log(animator.GetBool(ANIMATOR_ISOPEN));
    // }
}
