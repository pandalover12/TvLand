using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableSphereChild : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        transform.position = GetComponentInParent<Transform>().position;
        transform.rotation = GetComponentInParent<Transform>().rotation;
        transform.localScale = GetComponentInParent<Transform>().localScale;
        GetComponent<CircleCollider2D>().radius = transform.localScale.x / 2;
	}
	
}
