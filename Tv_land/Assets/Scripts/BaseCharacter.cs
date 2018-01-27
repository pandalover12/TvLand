using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Speed the character moves with")]

    [SerializeField]
    float maxSpeed;
    Vector2 input;

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
    protected Rigidbody2D rd;

    //Jump cooldown
    //[Header("Cooldown for jumping")]
    //[SerializeField]
    //protected float jumpCooldown = 1.6f;
    //protected float jumpVar = 0;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    protected void Initialize()
    {
        rd = GetComponent<Rigidbody2D>();
        //jumpVar = jumpCooldown;
    }

    protected void Move()
    {
        //jumpCooldown -= Time.deltaTime;
        //Move right
        rd.velocity = new Vector2(input.x * maxSpeed *  1, rd.velocity.y);

        //Jump
        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1))
        {
            rd.AddForce(new Vector3(0, jumpUp, 0));
           // jumpCooldown = jumpVar;
        }
        //Todo: play crouch animation
        if(Input.GetKey(KeyCode.C))
        {

        }
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

    }

}
