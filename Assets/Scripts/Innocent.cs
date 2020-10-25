using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Innocent : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    private List<POI> tasks;

    private int current_task = -1;
    public float TimeStillToCompleteTask = 2.0f;
    public float DistanceToTask = 1.0f;
    public float MaxSpeedBeforeTask = 1.0f;
    public float RODistance;
    public float ROSpeed;
    private float countdown;
    private Timer timer;

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
        timer = new Timer(TimeStillToCompleteTask);
    }

    void ChooseTask()
    {
        if (tasks.Count == 0 || IsComplete)
        {
            current_task = -2;
            return;
        }
        current_task = UnityEngine.Random.Range(0, tasks.Count);

        var pos = tasks[current_task].transform.position;
        pos.y = transform.position.y;

        agent.SetDestination(pos);
    }

    void CompleteTask()
    {
        tasks.RemoveAt(current_task);
        ChooseTask();
    }

    float distance_to_task
    {
        get
        {
            var dest = agent.destination.vector2();
            var pos = transform.position.vector2();
            return Vector2.Distance(dest, pos);
        }
    }

    void Update()
    {
        if (IsComplete)
        {
            agent.SetDestination(GetComponentInParent<InnocentManager>().StartPosition);
            return;
        }
        RODistance = distance_to_task;
        ROSpeed = agent.velocity.magnitude;

        if (timer.tick(distance_to_task < DistanceToTask && agent.velocity.magnitude < MaxSpeedBeforeTask))
        {
            CompleteTask();
        }
    }
}
