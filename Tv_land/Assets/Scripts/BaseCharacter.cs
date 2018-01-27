using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Speed the character moves with")]
    [SerializeField]
    float moveSpeed = 10;

    [Header("Distanc player slides on releasing key")]
    [SerializeField]
    float slideDistance = 5;

    [Header("Amount of thrust player gets on jumping")]
    [SerializeField]
    float jumpUp = 400;

    //[Header("Amount of horizontal thrust player gets on jumping")]
    //[SerializeField]
    //float jumpDirection = 10;

    //Rigidbody of the component
    protected Rigidbody rd;

    //Jump cooldown
    [Header("Cooldown for jumping")]
    [SerializeField]
    protected float jumpCooldown = 1.6f;
    protected float jumpVar = 0;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    protected void Initialize()
    {
        rd = GetComponent<Rigidbody>();
        jumpVar = jumpCooldown;
    }

    protected void Move()
    {
        jumpCooldown -= Time.deltaTime;
        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            rd.AddForce(moveSpeed, 0, 0, ForceMode.Force);
        }

        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            rd.AddForce(-moveSpeed, 0, 0, ForceMode.Force);
        }

        //Jump
        if (Input.GetKey(KeyCode.W) && jumpCooldown <= 0)
        {
            rd.AddForce(new Vector3(0, jumpUp, 0));
            jumpCooldown = jumpVar;
        }
        //Todo: play crouch animation
        if(Input.GetKey(KeyCode.S))
        {

        }
        
    }

}
