using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject creditsMenu;

    Color originalColor;

    public void StartBtn()
    {
        //TODO : Load scene 1
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void ToggleOptionsMenu()
    {
        Debug.Log("Option");
        if(optionsMenu.activeInHierarchy)
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ToggleCreditsMenu()
    {
        Debug.Log("Credit");
        if (creditsMenu.activeInHierarchy)
        {
            creditsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            creditsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void LightUp()
    {
        Debug.Log("Entered");
        originalColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.red;
    }

    public void LightOut()
    {
        GetComponent<Image>().color = originalColor;
    }
}
