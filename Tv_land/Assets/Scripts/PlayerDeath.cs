using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    GameObject ButtonRestart;
    GameObject player;

    bool dead = false;

    [SerializeField]
    float deathDist = 10;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, deathDist);
    }

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
   deathScreen.SetActive(false);
        ButtonRestart.SetActive(false);
   player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Time.timeScale == 1 && Input.GetKey(KeyCode.Escape))
        {
            deathScreen.SetActive(true);
        }

        if(Time.timeScale == 0 && Input.GetKey(KeyCode.Escape))
        {
            deathScreen.SetActive(false);
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= deathDist)
        {
            Time.timeScale = 0;
            dead = true;
        }
        else if (player.transform.position.y < -10)
        {
            Time.timeScale = 0;
            dead = true;
        }

       if (dead)
       {
           deathScreen.SetActive(true);
           ButtonRestart.SetActive(true);
       }
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dead = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        //TODO: reload current scene
        SceneManager.LoadScene(1);
    }

    public void ToggleDead(bool b)
    {
        dead = b;
    }

    public bool GetDead()
    {
        return dead;
    }

}
