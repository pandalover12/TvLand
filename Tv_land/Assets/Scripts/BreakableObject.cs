using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    [SerializeField]
    GameObject spherePatricles;

    [SerializeField]
    int numParticles = 10;

    private void OnTriggerStay(Collider collision)
    {
    
        if(collision.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.Mouse0))
        {

            GetComponent<Rigidbody>().AddExplosionForce(1000, collision.transform.position, 1000);
            if(gameObject.tag == "BreakableSphere")
            {
                
            }
        }
    }

}
