using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Innocent : MonoBehaviour
{
    private NavMeshAgent agent;
    private List<POI> tasks;

    private int current_task = -1;

    public bool IsComplete
    {
        get
        {
            return current_task == -2;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        var manager = GetComponentInParent<InnocentManager>();
        tasks = new List<POI>(manager.GetTasks());

        ChooseTask();
    }

    void ChooseTask()
    {
        if (tasks.Count == 0 || IsComplete)
        {
            current_task = -2;
            return;
        }
        current_task = UnityEngine.Random.Range(0, tasks.Count);
        agent.SetDestination(tasks[current_task].transform.position);
    }

    void CompleteTask()
    {
        tasks.RemoveAt(current_task);
        ChooseTask();
    }

    void Update()
    {
        if (IsComplete)
        {
            agent.SetDestination(GetComponentInParent<InnocentManager>().StartPosition);
            return;
        }

        // Debug.Log((agent.destination - transform.position).magnitude);
        if ((agent.destination - transform.position).magnitude < 1.0f)
        {
            // Debug.Log("CompleteTask");
            CompleteTask();
        }
    }
}
