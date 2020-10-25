using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    const string ANIMATOR_SPEED = "Speed";
    public const string ANIMATOR_DANCE = "Dance";
    public bool Dance;

    public string chefColor;

    private Innocent innocent;
    private Animator animator;

    void Start()
    {
        innocent = GetComponent<Innocent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat(ANIMATOR_SPEED, innocent.agent.velocity.magnitude / innocent.agent.speed);

        if (Dance)
        {
            TriggerDance();
        }
    }

    public void TriggerDance()
    {
        animator.SetTrigger(ANIMATOR_DANCE);
    }
}
