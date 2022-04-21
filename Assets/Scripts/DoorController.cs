using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool IsInTrigger;
    private Animator animator;
    public GameObject instructions;

    void Update()
    {
        if(IsInTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("OpenClose");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            IsInTrigger = true;
            instructions.SetActive(true);
            animator = other.GetComponentInChildren<Animator>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            instructions.SetActive(false);
        }
    }
}
