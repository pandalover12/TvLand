using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCollision : MonoBehaviour
{

    GameObject[] destructionParticles;
	
	// Update is called once per frame
	void Update ()
    {
        destructionParticles = new GameObject[GameObject.FindGameObjectsWithTag("DestructionParticle").Length];
        destructionParticles = GameObject.FindGameObjectsWithTag("DestructionParticle");

        for (int i = 0; i < destructionParticles.Length; i++)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), destructionParticles[i].GetComponent<Collider>());
        }

    }
}
