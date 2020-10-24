using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InnocentManager : MonoBehaviour
{
    public PoiManager PoiManager;
    public int NumTasks;
    public int NumInnocents;
    public GameObject InnocentPrefab;
    public Vector3 StartPosition;

    public POI[] GetTasks()
    {
        return PoiManager.GenerateRandom(NumTasks);
    }

    public void Start()
    {
        for (int x = 0; x < NumInnocents; x++)
        {
            var innocent = Instantiate(InnocentPrefab, StartPosition, Quaternion.identity);
            innocent.transform.SetParent(transform);
        }
    }

    void Update()
    {
    }
}
