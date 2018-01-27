using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().AddExplosionForce(1000, collision.transform.position, 1000);
        }
    }

}
