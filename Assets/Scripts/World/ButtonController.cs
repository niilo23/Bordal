using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Animation removed due to bugs
    //FIX private Animator buttonAnimator;
    private Animator DoorAnimator;

    private float replayCooldown = 2.5f;
    private float timer = 0;

    private AudioSource source;
    public AudioClip beep;

    public GameObject linkedDoor;

    private AudioSource doorSource;
    public AudioClip linkedDoorSound;

    void Start()
    {
        //FIX buttonAnimator = GetComponent<Animator>();

        // Gets all necessary components for sounds & animations.
        source = this.GetComponent<AudioSource>();
        DoorAnimator = this.linkedDoor.GetComponent<Animator>();
        doorSource = this.linkedDoor.GetComponent<AudioSource>();
    }

    // Timer so buttonSound doesn't play five million times a second
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) {timer = 0; }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Movable is tag given to objects that are movable and are wanted to make the button work.
        if (other.gameObject.tag == "Movable")
        {
            //FIX this.buttonAnimator.SetTrigger("ObjectOnButton");
            if (timer <= 0)
            {
                source.PlayOneShot(beep, 1.0f);
                timer = replayCooldown;
            }

            DoorAnimator.SetTrigger("buttonOpen");
            doorSource.PlayOneShot(linkedDoorSound, 0.5f);
        }
    }

    private void OnCollisionExit()
    {
        //FIX buttonAnimator.SetTrigger("ObjectNotOnButton");

        DoorAnimator.SetTrigger("buttonClose");
        doorSource.PlayOneShot(linkedDoorSound, 0.5f); 
    }
}
