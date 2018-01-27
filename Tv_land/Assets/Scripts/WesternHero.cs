using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternHero : BaseCharacter
{
    [SerializeField]
    GrappleScpt grappleScript;
    [SerializeField]
    float grappleControlMax = 10;
    [SerializeField]
    float grappleStartingControl = 0.2f;
    [SerializeField]
    float grappledControl = 0.5f;
    float inAirSpeedMult = 0.5f;
  
    [SerializeField]
    GameObject GrappleTarget;
    [SerializeField]
    GameObject cursorPos;

    // Use this for initialization
    void Start () {
        base.Initialize();

    }
	
	// Update is called once per frame
	    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 17;
        cursorPos.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 zeropo = cursorPos.transform.position;
            zeropo.z = 0;
            GrappleTarget.transform.position = zeropo;
            grappleScript.StartGrapple();
         //   Debug.Break();

        }
        if (Input.GetKey(KeyCode.Space)&&grappleScript.GetCurHook()!=null&& grappleScript.GetCurHook().GetComponent<GrappleHook>().done == true&&onGround==false)
        {
            grappleScript.DestroyGrapple();
            rd.AddForce(new Vector2(0, jumpUp));
        }
            base.Move(false);
        if (grappleScript.GetCurHook() == null && onGround == false)
        {
            rd.velocity = new Vector2(input.x * maxSpeed * 1, rd.velocity.y);
        //    jumpUp = 100;
        }

              if (grappleScript.GetCurHook() != null && grappleScript.GetCurHook().GetComponent<GrappleHook>().GetGrappleHookDone() && !grappleScript.GetCurHook().GetComponent<GrappleHook>().reelingIn && Mathf.Abs(input.x) > float.Epsilon&& onGround == false)
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
         //   RaycastHit2D wallHit = Physics2D.Raycast(transform.position, (Vector2.right * input.x).normalized, 0.5f, groundlayer);
            Debug.DrawRay(transform.position, (Vector2.right * input.x).normalized, Color.white, Time.deltaTime);
            if (/*wallHit.collider == null &&*/ (Mathf.Sign(input.x) != Mathf.Sign(rd.velocity.x) || Mathf.Abs(rd.velocity.x) < 7))
            {
                rd.velocity += Vector2.right * input.x * inAirSpeedMult;
                Debug.Log("Swing");
            }
        }
    }

}
