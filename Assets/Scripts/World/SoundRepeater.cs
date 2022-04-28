using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRepeater : MonoBehaviour
{
    // Scripts for repeating sounds randomly
    // Used in this game for random ambient sounds, mainly rat sounds

    public float counter = 5f;
    public float time1;
    public float time2;

    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = this.GetComponent<AudioSource>();

        counter = Random.Range(time1, time2);
    }

    void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0f)
        {
            source.PlayOneShot(clip, 0.5f);

            // Reset counter
            counter = Random.Range(time1, time2);
        }
    }
}
