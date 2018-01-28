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
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip cons;
    [SerializeField]
    AudioClip drn;
    [SerializeField]
    AudioClip lfe;
  

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
            source.clip = cons;
            source.Play();
            ++coins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drink")
        {
            source.clip = drn;;
            source.Play();
            ++drinks;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Life")
        {
            source.clip = lfe;
            source.Play();
            ++extraLives;
            Destroy(collision.gameObject);
        }
    }
}
