using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControler : MonoBehaviour {
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip heros;
    [SerializeField]
    AudioClip Western;
    [SerializeField]
    AudioClip Midevil;
  public  int switcher;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
        if (switcher == 1)
        {
            source.clip = heros;

            if(source.isPlaying==false)
            source.Play();

        }
        else if (switcher == 2)
        {
            source.clip = Western;
            if (source.isPlaying == false)
                source.Play();
        }
        else if (switcher == 3)
        {
            source.clip = Midevil;
            if (source.isPlaying == false)
                source.Play();
        }

    }
}
