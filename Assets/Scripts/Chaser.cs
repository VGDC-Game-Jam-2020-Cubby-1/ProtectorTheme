using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    private NavMeshAgent chaser;

    public List<POI> targets;
    private GameObject chef;

    private bool hasTarget;


    // Start is called before the first frame update
    void Start()
    {
        chaser = GetComponent<NavMeshAgent>();
        chef = GameObject.FindGameObjectWithTag("Chef");
        

        

        // var manager = GetComponentInParent<InnocentManager>();
        // targets = new List<POI>(manager.GetTasks());

    }

    // Update is called once per frame
    void Update()
    {   
        if(!hasTarget)
        {
            chef = GameObject.FindGameObjectWithTag("Chef");
            hasTarget = true;
        }

        if(chef != null)
        {
            chaser.SetDestination(chef.transform.position);
        }   

    

    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.tag);
        if(other.tag == "Chef")
        {
            Kill(other);

        }
    }
    void ChooseTarget()
    {
        
    }

    private void Kill(Collider other){
        Debug.Log("Kill" + other);
        Destroy(other.gameObject);
    }
}
