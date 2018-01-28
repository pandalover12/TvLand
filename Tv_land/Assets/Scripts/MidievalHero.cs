using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidievalHero : BaseCharacter
{
    [SerializeField]
    GameObject hammer;

	// Use this for initialization
	void Start ()
    {
        base.Initialize();
        EnableHammer();
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
    public void EnableHammer()
    {
        hammer.SetActive(true);
    }
    public void DsableHammer()
    {
        hammer.SetActive(false);
    }

    private void OnDisable()
    {
        DsableHammer();
    }

}

