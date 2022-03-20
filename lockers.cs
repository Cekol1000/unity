using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockers : MonoBehaviour
{
    public Animator animator;
    public AudioSource openingSFX;
    public AudioSource closingSFX;
    bool PlayerRaycasting;
    public Camera DoorRayCamera;
    bool CanRepeat = true;
    private bool isUsed = false;
    private bool isPlayerInTrigger = false;
     void Start()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isPlayerInTrigger = true;
        }  
    }

     void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }

     void Update()
    {
        RaycastHit hit;
        Ray ray = DoorRayCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "touchable_int")
            {
                PlayerRaycasting = true;
            }
            else
            {
                PlayerRaycasting = false;
            }
        }
        if (!isUsed && isPlayerInTrigger && Input.GetKeyDown("e") && CanRepeat && PlayerRaycasting)
        {
            animator.SetBool("isOpening", true);
            openingSFX.Play();
            animator.SetBool("isClosing", false);
            isUsed = true;
            CanRepeat = false;
            StartCoroutine(CoolDown());
        }
        else
        {
            if (isUsed && isPlayerInTrigger && Input.GetKeyDown("e") && CanRepeat && PlayerRaycasting)
            {
                animator.SetBool("isOpening", false);
                animator.SetBool("isClosing", true);
                closingSFX.Play();
                isUsed = false;
                CanRepeat = false;
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.2f);
        CanRepeat = true;
    }
}
