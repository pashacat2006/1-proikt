using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ешьу : MonoBehaviour
{
    public int count1 = 0;
    public GameObject monster;
    public Transform t;
    public void time()
    {
        count1++;
        if (count1 == 20)
        {
            monster.transform.position = t.transform.position;
            return;
        }
    }
    public void Update()
    {
        time();
    }
}
