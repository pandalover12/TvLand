using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    [SerializeField]
    GameObject destructionParticle;

    [SerializeField]
    int numParticles = 10;
    [SerializeField]
    float explosionForce = 10;
    [SerializeField]
    float explosionRange = 10;

    List<GameObject> particles;

    private void Start()
    {
        if (particles == null)
            particles = new List<GameObject>();

        float randomX = UnityEngine.Random.Range(0, transform.localScale.x / 2);
        float randomY = UnityEngine.Random.Range(0, transform.localScale.y / 2);
        float randomZ = UnityEngine.Random.Range(0, transform.localScale.z / 2);

        float xMul = 0;
        float yMul = 0;
        float zMul = 0;

        while(xMul != 0 && yMul != 0 && zMul != 0)
        {
            xMul = Random.Range(-1, 1);
            yMul = Random.Range(-1, 1);
            zMul = Random.Range(-1, 1);
        }

        for (int i = 0; i < numParticles; i++)
        {
            GameObject tempVar;
            
            tempVar = Instantiate(destructionParticle, new Vector3(transform.position.x + randomX * xMul, transform.position.y + randomY * yMul, transform.position.z + randomZ * zMul), Random.rotation);

            tempVar.SetActive(false);
            particles.Add(tempVar);
        }
        


    }

    private void OnCollisionStay(Collision collision)
    {
    
        if(collision.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.Mouse0))
        {

            for (int i = 0; i < numParticles; i++)
            {

                particles[i].SetActive(true);
                
                particles[i].GetComponent<Rigidbody>().AddExplosionForce(Random.Range(explosionForce / 2, explosionForce), transform.position, explosionRange);

                Destroy(particles[i], 2f);
            }

            Destroy(gameObject);

            GetComponent<Rigidbody>().AddExplosionForce(100, collision.transform.position, 1000);
        }

    }

}
