using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidievalHero : BaseCharacter
{
    [SerializeField]
    GameObject hammer;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip wal;
    [SerializeField]
    AudioClip hammersound;

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
            if (source.clip != hammersound)
                source.clip = hammersound;
            if (source.isPlaying == false)
                source.Play();
        }
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 - 0.1f), Vector2.down, 0.1f))
        {
            //  Debug.Break();
            onGround = true;
            //jumpUp = jumpVar;
         //   rd.velocity = new Vector2(input.x * maxSpeed * 1, rd.velocity.y);
        }
        if (onGround && input.x != 0)
        {
            if (source.clip != wal)
                source.clip = wal;
            if (source.isPlaying == false)
                source.Play();
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

