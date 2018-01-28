using UnityEngine;
using System.Collections;

public class hodey : MonoBehaviour
{

    private Cloth clothMod;
    private Vector3 TargetWindForce;

    public Vector3 MaxWindForce;
    public float WindForceIntervals = 1;
    public Vector3 NegativeWindForce;

    // Use this for initialization
    void Start()
    {
        clothMod = this.GetComponent<Cloth>();
        clothMod.externalAcceleration = NegativeWindForce;
        TargetWindForce = MaxWindForce;
        if (WindForceIntervals <= 0)
        {
            WindForceIntervals = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        clothMod.externalAcceleration = Vector3.MoveTowards(clothMod.externalAcceleration, TargetWindForce, WindForceIntervals);
        Debug.Log(clothMod.externalAcceleration);
   //     clothMod.externalAcceleration = new Vector3(clothMod.externalAcceleration.x + Random.Range(0, 3 ), clothMod.externalAcceleration.y, clothMod.externalAcceleration.z);

        if (clothMod.externalAcceleration == MaxWindForce)
        {
          
            TargetWindForce = NegativeWindForce;
        }
        if (clothMod.externalAcceleration == NegativeWindForce)
        {
            MaxWindForce = new Vector3(Random.Range(-100, -90), 30, -40);
            NegativeWindForce = new Vector3(Random.Range(0, 10), -30, 0);
            TargetWindForce = MaxWindForce;

        
        }
    }
}
