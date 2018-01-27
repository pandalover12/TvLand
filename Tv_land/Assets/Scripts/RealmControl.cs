using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmControl : MonoBehaviour {
    [SerializeField]
    WesternHero westhero;
    [SerializeField]
    MidievalHero hamerguy;
    [SerializeField]
    SuperHero superguys;
    [SerializeField]
    Materalcontrol mat;

	// Use this for initialization
	void Start () {
        superguys.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey(KeyCode.L))) { 
            if (superguys.enabled == true)
            {
                mat.switchmat = 1;
                superguys.enabled = false;
                westhero.enabled = true;
            }
            else if (westhero.enabled == true)
            {
                mat.switchmat = 2;
                westhero.enabled = false;
                hamerguy.enabled = true;
            }

            else
            {
                mat.switchmat = 0;
                hamerguy.enabled = false;
                superguys.enabled = true;
            }
        }

    }
}
