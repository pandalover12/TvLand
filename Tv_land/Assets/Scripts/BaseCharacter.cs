using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Speed the character moves with")]

    [SerializeField]
    protected float maxSpeed;
    [SerializeField]
    protected Vector2 input;

    [Header("Distanc player slides on releasing key")]
    [SerializeField]
    protected float slideDistance = 5;

    [Header("Amount of thrust player gets on jumping")]
    [SerializeField]
    protected float jumpUp = 400;
    protected float jumpVar = 1f;

    protected bool onGround = false;

    //Rigidbody of the component
    protected Rigidbody2D rd;
   
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    protected void Initialize()
    {
        rd = GetComponent<Rigidbody2D>();
        jumpVar = jumpUp;
    }

    protected void Move()
    {
        
        if(Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 - 0.1f), Vector2.down, 0.1f))
        {
            onGround = true;
            //jumpUp = jumpVar;
            rd.velocity = new Vector2(input.x * maxSpeed * 1, rd.velocity.y);
        }
        else
        {
            onGround = false;
            //jumpUp -= Time.deltaTime;
           
        }

 

        //Jump
        if (Input.GetKey(KeyCode.Space) && Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 - 0.1f), Vector2.down, 0.1f))
        {
            rd.AddForce(new Vector2(0, jumpUp));
        }

        //Todo: play crouch animation
        if(Input.GetKey(KeyCode.C))
        {

        }

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

    }

}
