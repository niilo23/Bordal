using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunkScript : MonoBehaviour
{
    // Script for physics objects thunking when impacting ground

    private AudioSource Source;
    public AudioClip thunkSound;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.tag == "Movable")
        Source.PlayOneShot(thunkSound, 0.5f);

        // Changes pitch randomly so not all thunks are same
        Source.pitch = 1f + Random.Range(-0.35f, 0.35f);
    }
}
