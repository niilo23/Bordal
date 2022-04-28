using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour
{
    private bool IsInTrigger;
    private Animator animator;
    public Text instructions;

    void Update()
    {
        if(IsInTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            // Trigger used in manual doors. Button doors are controlled thru button script
            animator.SetTrigger("OpenClose");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            IsInTrigger = true;
            instructions.enabled = true;
            animator = other.GetComponentInChildren<Animator>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            instructions.enabled = false;
            IsInTrigger = false;
        }
    }
}
