using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternHero : BaseCharacter {

	// Use this for initialization
	void Start () {
        base.Initialize();

    }
	
	// Update is called once per frame
	void FixedUpdate() {    
        base.Move();
         else if (grappleScript.GetCurHook() != null && grappleScript.GetCurHook().GetComponent<GrappleHook>().GetGrappleHookDone() && !grappleScript.GetCurHook().GetComponent<GrappleHook>().reelingIn && Mathf.Abs(input.x) > float.Epsilon)
        {


            if (Mathf.Sign(input.x) == Mathf.Sign(rd.velocity.x))
            {
                if (rd.velocity.sqrMagnitude < grappleControlMax)
                {
                    // if the rd.velocity is smaller than the small grapple control value then mutply the velocity
                    if (rd.velocity.sqrMagnitude < grappleStartingControl)
                    {
                        rd.velocity *= Mathf.Abs(input.x) * grappledControl + 1;

                    }
                    // then just add it so that its not to much
                    else
                    {
                        rd.velocity += new Vector2(input.x * grappledControl, 0);

                    }
                }
            }
            // The player is moving opposite the swinging direction
            else
                rd.velocity /= 1.025f;

        }
        else if (input.x != 0)
        {
            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, (Vector2.right * input.x).normalized, 0.5f, groundlayer);
            Debug.DrawRay(transform.position, (Vector2.right * input.x).normalized, Color.white, Time.deltaTime);
            if (wallHit.collider == null && (Mathf.Sign(input.x) != Mathf.Sign(rd.velocity.x) || Mathf.Abs(rd.velocity.x) < maxSpeed))
            {
                rd.velocity += Vector2.right * input.x * inAirSpeedMult;
                Debug.Log("Swing");
            }
        }
    }
}
