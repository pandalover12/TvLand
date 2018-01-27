using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    private void OnTriggerStay(Collider collision)
    {
    
        if(collision.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().AddForce(new Vector2(0, 100));


            GetComponent<Rigidbody>().AddExplosionForce(100, collision.transform.position, 1000);
        }
    }

}
