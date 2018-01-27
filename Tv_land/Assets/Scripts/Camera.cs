using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Drag and drop player gameobject here")]
    [SerializeField]
    GameObject player;

    [SerializeField]
    float lerpSpeed = 1;

    Vector3 velocity = Vector3.zero;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), ref velocity, lerpSpeed);
	}
}
