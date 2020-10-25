using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSide : MonoBehaviour
{
    private Animator animator;
    const string ANIMATOR_ISOPEN = "IsOpen";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetOpen(bool isOpen)
    {
        animator.SetBool(ANIMATOR_ISOPEN, !isOpen);
    }
}
