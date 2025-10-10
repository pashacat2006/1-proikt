using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moster : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    public GameData monster;
    [SerializeField]
    private GameObject player;
    [SerializeField] private Animator _animator;
    private bool isReload = true;
    [SerializeField]
    private healch hel;
    private bool startReload = false;
    public IEnumerator enumerator() 
    {
        startReload = true;
        if (isReload == false)
        {
            yield return new WaitForSeconds(5);
            isReload = true;
            startReload = false;
        }
    }

    private void Start()
    {
        _animator.enabled = true;
    }

    private void Update()
    {
        Move();
        damage();
        if (startReload == false && isReload == false)
        {
            StartCoroutine(enumerator());
        }
    }
    void damage()
    {
        if (Vector3.Distance(transform.position,player.transform.position) < 3)
        {
            if (isReload == true)
            {
                hel.Health();
                isReload = false;
            }
        }
    }
    void Move()
    {
        bool isWalk = _animator.GetBool("IsWalk");
        float viewRange = 10;


        if (Vector3.Distance(transform.position,player.transform.position) < viewRange)
        {
            if (!isWalk)
            {
                _animator.SetBool("IsWalk", true);
                print(_animator.GetBool("IsWalk"));
            }

            print("walk");
            agent.SetDestination(player.transform.position);
        }
        else if(Vector3.Distance(transform.position, player.transform.position) > viewRange)
        {
            print("not walk");
            if (isWalk)
            {
                _animator.SetBool("IsWalk", false);
            }
            agent.ResetPath();
        }
    }
}
