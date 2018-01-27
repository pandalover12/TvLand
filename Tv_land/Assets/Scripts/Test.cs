using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : BaseCharacter 
    {

	// Use this for initialization
	void Start ()
    {
        base.Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        base.Move();
	}
}
