using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class doorsInteraction : MonoBehaviour
{
    public GameObject Player;
    public Camera DoorRayCamera;
    bool isPlayerInTrigger = false;
    bool PlayerRaycasting = false;
    public GameObject door;
    bool isDoorOpen = false;
    public AudioSource doorOpening;
    public AudioSource doorClosing;
    public bool isDoorLocked = false;
    public GameObject InfoUI;
    private TextMeshProUGUI InfoUIConverted;
    private bool lockedCoolDown;
    public string KeyType;
    //TextMeshProUGUI TMPtextInfo;
    public int KeyValue;
    bool CanRepeat = true;
    Animator Anim;
    bool isSprinting_2;
    // private Animator Anim;
    private void Start()
    {
        InfoUIConverted = InfoUI.GetComponent<TextMeshProUGUI>();
        Anim = door.GetComponent<Animator>();
    }
     void OnTriggerEnter(Collider col)
    {
        isPlayerInTrigger = true;
    }

     void OnTriggerExit(Collider other)
    {
        isPlayerInTrigger=false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = DoorRayCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == "touchable_int")
            {
                PlayerRaycasting = true;
            }
            else
            {
                PlayerRaycasting = false;
            }
        }   
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown("e") && !isDoorLocked && PlayerRaycasting)
            {
                if(isDoorOpen == false && CanRepeat)
                {
                    Anim.SetBool("isOpening", true);
                    isDoorOpen = true;
                    doorOpening.Play();
                    CanRepeat = false;
                    StartCoroutine(CoolDown());
                }
                else
                {
                    if(isDoorOpen == true && CanRepeat)
                    {
                        Anim.SetBool("isOpening", false);
                        isDoorOpen=false;
                        doorClosing.Play();
                        CanRepeat=false;
                        StartCoroutine(CoolDown());
                    }
                }
            }
            else
            {
                if(Input.GetKeyDown("e") && isDoorLocked && PlayerRaycasting && !lockedCoolDown)
                {
                    InfoUIConverted.text = "You need key to open these door.";
                    StartCoroutine(clearTMP());
                    lockedCoolDown = true;
                }
            }
        }

    }

    IEnumerator clearTMP()
    {
        yield return new WaitForSeconds(6);
        InfoUIConverted.text = "";
        lockedCoolDown = false;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        CanRepeat = true;
    }
}


