using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    AudioClip superCoin;
    [SerializeField]
    AudioClip westernCoin;
    [SerializeField]
    AudioClip midievalCoin;
    [SerializeField]
    AudioClip superDrink;
    [SerializeField]
    AudioClip westernDrink;
    [SerializeField]
    AudioClip midievalDrink;
    [SerializeField]
    AudioClip lfe;

    [SerializeField]
    GameObject UiUpdate;
  
    public int switcher;
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
            if (switcher == 1)
                source.clip = superCoin;
            else if (switcher == 2)
                source.clip = westernCoin;
            else
                source.clip = midievalCoin;

            source.Play();
            ++coins;
            GameObject.Find("coinCount").GetComponent<Text>().text = coins.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Drink")
        {
            if (switcher == 1)
                source.clip = superDrink;
            else if (switcher == 2)
                source.clip = westernDrink;
            else
                source.clip = midievalDrink;
            source.Play();
            ++drinks;
            GameObject.Find("drinkCount").GetComponent<Text>().text = drinks.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Life")
        {
            source.clip = lfe;
            source.Play();
            ++extraLives;
            GameObject.Find("lifeCount").GetComponent<Text>().text = extraLives.ToString();
            Destroy(collision.gameObject);
        }
    }
}
