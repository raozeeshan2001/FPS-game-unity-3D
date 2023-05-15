using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    Animator enemyanim;
    public float detectionradius = 12f;
    void Start()
    {
        enemyanim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        float distance=Vector3.Distance(transform.position, player.transform.position);
        if (distance <= detectionradius)
        {
            agent.SetDestination(player.transform.position);
            enemyanim.SetBool("walk", true);
        }
        else
        {
            enemyanim.SetBool("walk", false);
            enemyanim.SetBool("donothing",true);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionradius); 
    }
}
