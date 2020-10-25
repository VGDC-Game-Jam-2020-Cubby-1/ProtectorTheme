using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    private NavMeshAgent chaser;

    private GameObject target;
    private GameObject[] chefs;
    
    private bool hasTarget;

    public float killCooldown = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        chaser = GetComponent<NavMeshAgent>();
        chefs = GameObject.FindGameObjectsWithTag("Chef");
        if(chefs == null)
        {
            hasTarget = false;
        }
        
        

        

        // var manager = GetComponentInParent<InnocentManager>();
        // targets = new List<POI>(manager.GetTasks());

    }

    // Update is called once per frame
    void Update()
    {   
        killCooldown -= Time.deltaTime;
        Debug.Log(killCooldown);
        if(!hasTarget)
        {
            target = ChooseTarget();
        }

        chaser.destination = target.transform.position;
        
    

    }

    private void OnTriggerEnter(Collider other) 
    {
        // Debug.Log(other.tag);
        if(other.tag == "Chef")
        {
            Kill(other);
        }
    }
    private GameObject ChooseTarget()
    {
      
        chefs = GameObject.FindGameObjectsWithTag("Chef");
        GameObject closestChef = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject chef in chefs) {
            Vector3 diff = chef.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closestChef = chef;
                distance = curDistance;
            }
        }

        
        hasTarget = true;
        return closestChef;
        
        
    }

    //TODO: Needs Cooldown
    private void Kill(Collider other){
        if(killCooldown <= 0f && target == other)
        {
            Debug.Log("Kill" + other);
            Destroy(other.gameObject);
            hasTarget = false;
        }
        
    }
}
