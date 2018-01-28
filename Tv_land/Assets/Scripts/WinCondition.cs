using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    [SerializeField]
    float winDistance = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, winDistance);
    }

}
