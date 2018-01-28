using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    [SerializeField]
    float winDistance = 5f;

    GameObject player;

    bool won = false;
    [SerializeField]
    GameObject WonText;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WonText.SetActive(false);

    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= winDistance)
        {
            won = true;
           
        }
        if (won == true)
        {
            WonText.SetActive(true);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, winDistance);
    }

}
