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
    private float jump = 300;
    [SerializeField]
    private Rigidbody phy;
    private Transform camer;

    [SerializeField] private TerrainChecker _terrainChecker;

    private void FixedUpdate()
    {
        Move();
        LimitSpeed();
    }
    private void Move()
    {
        bool isGround = _terrainChecker.IsCollide;

        if (Input.GetKey(KeyCode.W) && isGround)
        {
            phy.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S) && isGround)
        {
            phy.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D) && isGround)
        {
            phy.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A) && isGround)
        {
            phy.AddForce(-transform.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGround)
            {
                phy.velocity = new Vector3(phy.velocity.x, 0, phy.velocity.z);
                phy.AddForce(Vector3.up * jump);
            }
        }
    }

    private void LimitSpeed()
    {
        if (phy.velocity.magnitude > 10)
        {
            phy.velocity = phy.velocity.normalized * 10;
        }
    }
}
