using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moster : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (Vector3.Distance(transform.position,player.transform.position)< 10)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }
}
