using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField]
    GameObject deathScreen;
    bool dead = false;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dead)
        {

            Time.timeScale = 0;
        }
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dead = true;
        }
    }

    public void toggleDead(bool b)
    {
        dead = b;
    }

    public bool getDead()
    {
        return dead;
    }

}
