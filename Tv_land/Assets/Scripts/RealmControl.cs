using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmControl : MonoBehaviour {
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip swap;
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
    [SerializeField]
    GameObject knob;
    [SerializeField]
    musicControler musc;
    [SerializeField]
    GameObject POSES;
    [SerializeField]
    GameObject poses2s;
    [SerializeField]
    GameObject poss2;
    [SerializeField]
    Collectables collect;
    [SerializeField]
     SkinnedMeshRenderer cape;
    enum Channel {Super, Western, Midieval};


    // Use this for initialization
    void Start ()
    {
        ChangeChannel(2);
	}

    // Update is called once per frame
    void FixedUpdate()
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

    }

    public void ChangeChannel(int num)
    {
        if(source.clip!=swap)
        source.clip = swap;
        if (source.isPlaying == false)
        {
            source.Play();
        }
        switch (num)
        {
                
            case 1: //channel 1: Super Hero
                cape.enabled = true;
                poss2.SetActive(true);
                poses2s.SetActive(false);
                POSES.SetActive(false);
                superHero.enabled = true;
                knob.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -25));
                if (westernHero.enabled==true)
                westernHero.destroy();
                westernHero.enabled = false;
                if (midievalHero.enabled == true)
                {
                    midievalHero.DsableHammer();
                }
                midievalHero.enabled = false;
                musc.switcher = 1;
                mat.switchmat = 1;
                collect.switcher = 1;
                break;
            case 2: //channel 2: Western Hero
                cape.enabled = false;
                poss2.SetActive(false);
                poses2s.SetActive(true);
                POSES.SetActive(false);
                musc.switcher = 2;
                westernHero.enabled = true;
                knob.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -45));

                superHero.enabled = false;
                if (midievalHero.enabled == true)
                {
                    midievalHero.DsableHammer();
                }
                midievalHero.enabled = false;
                musc.switcher = 2;
                collect.switcher = 2;
                mat.switchmat = 2;
                break;
            case 3: //channel 3: Midieval Hero
                cape.enabled = false;
                poss2.SetActive(false);
                poses2s.SetActive(false);
                POSES.SetActive(true);
                midievalHero.enabled = true;
                knob.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -65));

                midievalHero.EnableHammer();
                superHero.enabled = false;
                if (westernHero.enabled == true)
                    westernHero.destroy();
                westernHero.enabled = false;
             //   Debug.Break();
                musc.switcher = 3;
                collect.switcher = 3;
                mat.switchmat = 3;
                break;
            default:
                Debug.Log("Error changing channel");
                break;
        }

    }
}
