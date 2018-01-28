using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    uint coins;
    [SerializeField]
    uint drinks;
    [SerializeField]
    uint extraLives;

  

    void Start ()
    {
        coins = 0;
        drinks = 0;
        extraLives = 0;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            ++coins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drink")
        {
            ++drinks;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Life")
        {
            ++extraLives;
            Destroy(collision.gameObject);
        }
    }
}
