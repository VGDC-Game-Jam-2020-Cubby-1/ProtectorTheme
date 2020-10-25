using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    private NavMeshAgent chaser;

    private GameObject target;

    public float killCooldownTime = 5.0f;
    private Timer killCooldown;

    private Shake shake;
    public GameObject chefParticles;

    private AudioSource screamFX;

    void Start()
    {
        chaser = GetComponent<NavMeshAgent>();
        killCooldown = new Timer(killCooldownTime);
        
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        screamFX = GameObject.FindGameObjectWithTag("ScreamSFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!killCooldown.tick(true))
        {
            return;
        }

        if (target == null)
        {
            target = ChooseTarget();
            if (target == null)
            {
                // No chefs left, game over
                enabled = false;
                return;
            }
        }
        chaser.destination = target.transform.position;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Chef" || !killCooldown.complete || other.gameObject != target)
        {
            return;
        }

        Kill(other);
    }

    private GameObject ChooseTarget()
    {
        var chefs = GameObject.FindGameObjectsWithTag("Chef");
        GameObject closestChef = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject chef in chefs)
        {
            Vector3 diff = chef.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestChef = chef;
                distance = curDistance;
            }
        }

        return closestChef;
    }

    //TODO: Needs Cooldown
    private void Kill(Collider other)
    {
        Debug.Log("Kill" + other);
        Destroy(other.gameObject);

        target = null;
        killCooldown.complete = false;

        shake.CamShake();
        screamFX.Play();

        Instantiate(chefParticles, other.transform.position, Quaternion.identity);
    }
}
