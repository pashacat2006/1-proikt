using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportsManagen : MonoBehaviour
{
    public Transform Teleport;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.transform.position = Teleport.transform.position;
        }
    }
}
