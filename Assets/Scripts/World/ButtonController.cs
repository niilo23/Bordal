using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator buttonAnimator;
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
        buttonAnimator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        DoorAnimator = linkedDoor.GetComponent<Animator>();
        doorSource = linkedDoor.GetComponent<AudioSource>();
    }

    // Timer so no earrape from buttonSound
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) { timer = 0; }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Movable")
        {
            buttonAnimator.SetTrigger("ObjectOnButton");

            DoorAnimator.SetTrigger("buttonOpen");
            doorSource.PlayOneShot(linkedDoorSound, 0.5f);

            if (timer <= 0)
            {
                source.PlayOneShot(beep, 1.0f);
                timer = replayCooldown;
            }
        }
    }

    private void OnCollisionExit()
    {
        buttonAnimator.SetTrigger("ObjectNotOnButton");

        DoorAnimator.SetTrigger("buttonClose");
        doorSource.PlayOneShot(linkedDoorSound, 0.5f); 
    }
}
