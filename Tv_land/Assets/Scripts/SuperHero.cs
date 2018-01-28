using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHero : BaseCharacter
{
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
        else if (!superJumpUsed && Input.GetMouseButtonDown(0))
            SuperJump();
    }

    public void SuperJump()
    {
        //rd.AddForce(new Vector2(0, 0));
        rd.velocity = Vector2.zero;

        rd.AddForce(new Vector2(0, superJumpUp));
        superJumpUsed = true;
    }
}
