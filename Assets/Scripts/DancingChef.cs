using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingChef : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetTrigger(Chef.ANIMATOR_DANCE);
    }
}
