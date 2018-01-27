using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my3mats : MonoBehaviour {
    [SerializeField]
   Renderer mat;
    [SerializeField]
    Material hero;
    [SerializeField]
    Material western;
    [SerializeField]
    Material hammer;
public  int swtcher = 0;

    // Use this for initialization
    void Start () {
        mat.material = hero;
	}
	
	// Update is called once per frame
	void Update () {
        if (swtcher == 0)
        {
            mat.material = hero;
        }
   else  if (swtcher == 1)
        {
            mat.material = western;
        }
        else
        {
            mat.material = hammer;
        }

    }
}
