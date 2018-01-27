using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public static uint superCoins;
    public static uint westernCoins;
    public static uint midievalCoins;

    public static uint superDrinks;
    public static uint westernDrinks;
    public static uint midievalDrinks;

    [SerializeField]
    BaseCharacter character;

    void Start ()
    {
        superCoins = 0;
        westernCoins = 0;
        midievalCoins = 0;

        superDrinks = 0;
        westernDrinks = 0;
        midievalDrinks = 0;
    }
	

	void FixedUpdate ()
    {
		

	}
}
