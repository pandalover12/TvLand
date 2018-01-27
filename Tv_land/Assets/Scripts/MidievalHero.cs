using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidievalHero : BaseCharacter
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
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //play hammer animation
        }
        
	}

}

