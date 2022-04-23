using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepScript : MonoBehaviour
{
    private bool isOnGround;
    private LayerMask ground;

    public float stepRate = 0.5f;
    public float stepCooldown;
    public AudioClip footstep;
    public AudioClip jump;
    public AudioClip land;
    public AudioSource feetAudioSource;

    void Start()
    {
        ground = GetComponent<PlayerMovement>().groundMask;
    }

    void Update()
    {
        stepCooldown -= Time.deltaTime;
        isOnGround = GetComponent<PlayerMovement>().isGrounded;

        if (isOnGround && Input.GetAxis("Horizontal") != 0f && stepCooldown <= 0f)
        {
            PlayFootstepSound();
        }
        else if(isOnGround && Input.GetAxis("Vertical") != 0f && stepCooldown <= 0f)
        {
            PlayFootstepSound();
        }

        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            feetAudioSource.PlayOneShot(jump, 0.5f);
        }
    }

    private void PlayFootstepSound()
    {
        feetAudioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
        feetAudioSource.PlayOneShot(footstep, 0.5f);
        stepCooldown = stepRate;
    }

    // Does not work and I won't even bother to make it work
    /*private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            feetAudioSource.PlayOneShot(land, 0.5f);
            Debug.Log("Hit the ground!");
        }
    }*/
}
