using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    [SerializeField]
    GameObject destructionSphere;

    [SerializeField]
    int numParticles = 10;
    [SerializeField]
    float explosionForce = 10;
    [SerializeField]
    float explosionRange = 10;

    private void OnTriggerStay(Collider collision)
    {
    
        if(collision.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.Mouse0))
        {

            Debug.Log("Blast");

            for (int i = 0; i < numParticles; i++)
            {
                float randomX = UnityEngine.Random.Range(0, transform.localScale.x / 2);
                float randomY = UnityEngine.Random.Range(0, transform.localScale.y / 2);
                float randomZ = UnityEngine.Random.Range(0, transform.localScale.z / 2);

                GameObject tempVar = Instantiate(destructionSphere, new Vector3(randomX, randomY, randomZ), Random.rotation);
                tempVar.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
                Destroy(tempVar, 2f);
            }

            Destroy(gameObject);

          //  GetComponent<Rigidbody>().AddExplosionForce(100, collision.transform.position, 1000);
        }

    }

}
