using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public GameObject playerMenu;
    public static bool isFlashlightItemEnabled = false;
    public static bool isKeysItemEnabled = false;
    public static bool isPillsItemEnabled = false;
    public GameObject flashlightIH, flIHlight, keysIH, pillsIH;
    private FirstPersonAIO PlayerController;

    void Start()
    {
        flashlightIH.SetActive(false);
        flIHlight.SetActive(false);
        /* test */
        PlayerController = GetComponent<FirstPersonAIO>();
    }
    void checkFlashlight()
    {
        if(Input.GetKeyDown("f") && isFlashlightItemEnabled && !flashlightIH.active)
        {
            flashlightIH.SetActive(true);
            flIHlight.SetActive(true);
        }
        else
        {
            if (Input.GetKeyDown("f") && flashlightIH.active)
            {
                flashlightIH.SetActive(false);
                flIHlight.SetActive(false);
            }
        }
    }
    void Update()
    {
        checkFlashlight();
    }
    public void EnableToSwitch(string item)
    {
        switch(item)
        {
            case "flashlight":
                isFlashlightItemEnabled = true;
                break;
            case "key":
                isKeysItemEnabled = true;
                break;
            case "pills":
                isPillsItemEnabled = true;
                break;
        }
    }
}
