using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject[] points_of_interest;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int key = 0; key < Math.Min(10, points_of_interest.Length); key++)
        {
            if (Input.GetKeyDown((KeyCode)(key + (int)KeyCode.Alpha1)))
            {
                var location = points_of_interest[key].transform.position;
                Debug.Log(key);
                Debug.Log(location);
                agent.SetDestination(location);
            }
        }
    }
}
