using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materalcontrol : MonoBehaviour {
    [SerializeField]
    GameObject[] ALWAYSTHESAMEbutnotsamemat = new GameObject[100];
    GameObject[] extraherostuff = new GameObject[10];
    GameObject[] extrawesternstuff = new GameObject[10];
    GameObject[] extrahamer = new GameObject[10];
    public  int switchmat = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (switchmat == 0) {

            for (int i = 0; i < 10; ++i)
            {
                ALWAYSTHESAMEbutnotsamemat[i].GetComponent<my3mats>().swtcher = 0;
            }
           for(int i =0; i < extraherostuff.Length; ++i)
            {
                extraherostuff[i].SetActive(  true);
            }
            for (int i = 0; i < extrawesternstuff.Length; ++i)
            {
                extrawesternstuff[i].SetActive(false);
            }
            for (int i = 0; i < extrahamer.Length; ++i)
            {
                extrahamer[i].SetActive(false);
            }

        }
   else     if (switchmat == 1)
        {

            for (int i = 0; i < 10; ++i)
            {
                ALWAYSTHESAMEbutnotsamemat[i].GetComponent<my3mats>().swtcher = 1;
            }
            for (int i = 0; i < extraherostuff.Length; ++i)
            {
                extraherostuff[i].SetActive(false);
            }
            for (int i = 0; i < extrawesternstuff.Length; ++i)
            {
                extrawesternstuff[i].SetActive(true);
            }
            for (int i = 0; i < extrahamer.Length; ++i)
            {
                extrahamer[i].SetActive(false);
            }

        }
 else       if (switchmat == 2)
        {

            for (int i = 0; i < 10; ++i)
            {
                ALWAYSTHESAMEbutnotsamemat[i].GetComponent<my3mats>().swtcher = 2;
            }
            for (int i = 0; i < extraherostuff.Length; ++i)
            {
                extraherostuff[i].SetActive(false);
            }
            for (int i = 0; i < extrawesternstuff.Length; ++i)
            {
                extrawesternstuff[i].SetActive(false);
            }
            for (int i = 0; i < extrahamer.Length; ++i)
            {
                extrahamer[i].SetActive(true);
            }

        }
    }
}
