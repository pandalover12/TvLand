using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmControl : MonoBehaviour {
    [SerializeField]
    WesternHero westernHero;
    [SerializeField]
    MidievalHero midievalHero;
    [SerializeField]
    SuperHero superHero;
    [SerializeField]
    Materalcontrol mat;
    bool button = false;
    float mouseWheelState = 0;
    [SerializeField]
    int channelNo = 2;
    enum Channel {Super, Western, Midieval};


    // Use this for initialization
    void Start ()
    {
        superHero.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (channelNo > 1)
                ChangeChannel(--channelNo);
            else
                ChangeChannel(channelNo += 2);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (channelNo < 3)
                ChangeChannel(++channelNo);
            else
                ChangeChannel(channelNo -= 2);
        }


    //    if ((Input.GetKey(KeyCode.L)) && button == false)
    //    {
    //        if (superHero.enabled == true)
    //        {

    //            mat.switchmat = 1;
    //            superHero.enabled = false;
    //            westernHero.enabled = true;
    //        }
    //        else if (westernHero.enabled == true)
    //        {

    //            mat.switchmat = 2;
    //            westernHero.enabled = false;
    //            midievalHero.enabled = true;
    //        }

    //        else
    //        {

    //            mat.switchmat = 0;
    //            midievalHero.enabled = false;
    //            superHero.enabled = true;
    //        }
    //        button = true;
    //        StartCoroutine(buttonbounce());
    //    }

    }
    //IEnumerator buttonbounce()
    //{
    //    yield return new WaitForSeconds(0.4f);
    //    button = false;
    //}

    public void ChangeChannel(int num)
    {
        switch (num)
        {
                
            case 1: //channel 1: Super Hero
                superHero.enabled = true;
                if(westernHero.enabled==true)
                westernHero.destroy();
                westernHero.enabled = false;
                if (midievalHero.enabled == true)
                {
                    midievalHero.DsableHammer();
                }
                midievalHero.enabled = false;

                mat.switchmat = 1;
                break;
            case 2: //channel 2: Western Hero
                westernHero.enabled = true;
                superHero.enabled = false;
                if (midievalHero.enabled == true)
                {
                    midievalHero.DsableHammer();
                }
                midievalHero.enabled = false;
                mat.switchmat = 2;
                break;
            case 3: //channel 3: Midieval Hero
                midievalHero.enabled = true;
                midievalHero.EnableHammer();
                superHero.enabled = false;
                if (westernHero.enabled == true)
                    westernHero.destroy();
                westernHero.enabled = false;
             //   Debug.Break();
                mat.switchmat = 3;
                break;
            default:
                Debug.Log("Error changing channel");
                break;
        }

    }
}
