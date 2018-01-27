using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [Header("Speed the character moves with")]
    [SerializeField]
    float moveSpeed = 10;

    [Header("Amount of thrust player gets on jumping")]
    [SerializeField]
    float jumpUp = 400;

    //[Header("Amount of horizontal thrust player gets on jumping")]
    //[SerializeField]
    //float jumpDirection = 10;

    //Rigidbody of the component
    Rigidbody rd;

    //Jump cooldown
    [Header("Cooldown for jumping")]
    [SerializeField]
    float jumpCooldown = 1.6f;
    float jumpVar = 0;

	// Use this for initialization
	void Start ()
    {
        rd = GetComponent<Rigidbody>();
        jumpVar = jumpCooldown;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        jumpCooldown -= Time.deltaTime;
        Move();
    }

    void Move()
    {
        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //Jump
        if(Input.GetKey(KeyCode.W) && jumpCooldown <= 0)
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
