using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHero : BaseCharacter
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip wal;
    [SerializeField]
    AudioClip doubljmp;
    [SerializeField]
    AudioSource doublejumpsound;
    [SerializeField]
    float superJumpMultiplier;

    private float superJumpUp;

    private bool superJumpUsed;
	void Start ()
    {
        base.Initialize();
        superJumpUp = jumpUp * superJumpMultiplier;
        superJumpUsed = false;

    }
	
	void FixedUpdate ()
    {
       
        base.Move();
        if (superJumpUsed && Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 - 0.1f), Vector2.down, 0.2f))
            superJumpUsed = false;
        else if (!superJumpUsed && Input.GetMouseButtonDown(0)&& !onGround&&jump)
            SuperJump();
     
        if (onGround && input.x != 0)
        {
         //   Debug.Break();
            if (source.clip != wal)
                source.clip = wal;
            if(source.isPlaying==false)
            StartCoroutine(soundstop());
        
        }
    }

    public void SuperJump()
    {
        if (doublejumpsound.clip != doubljmp)
            doublejumpsound.clip = doubljmp;
        doublejumpsound.Play();

        //rd.AddForce(new Vector2(0, 0));
        rd.velocity = Vector2.zero;
        Debug.Log(rd.velocity);
        rd.AddForce(new Vector2(0, superJumpUp));
        superJumpUsed = true;
    }
    IEnumerator soundstop()
    {
        yield return new WaitForSeconds(0.3f);
        if (source.isPlaying == false)
            source.Play();
    }
}
