using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float jump = 5;
    [SerializeField]
    private bool t;
   
    [SerializeField]
    private Rigidbody phy;
    private Transform camer;
    void OnCollisionEnter()
    {
        t = true;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            phy.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            phy.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            phy.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            phy.AddForce(-transform.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && t == true)
        {
            phy.AddForce(transform.up * jump);
            t = false;
        }
    }
}
