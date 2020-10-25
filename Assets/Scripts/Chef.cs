using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    const string ANIMATOR_SPEED = "Speed";
    public const string ANIMATOR_DANCE = "Dance";
    public bool Dance;

    public string chefColor;

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat(ANIMATOR_SPEED, agent.velocity.magnitude / agent.speed);

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
