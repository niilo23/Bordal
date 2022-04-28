using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Only place this script on player!
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            player.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }
}
