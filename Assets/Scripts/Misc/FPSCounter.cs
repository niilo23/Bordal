using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    private int avgFrameRate;
    private float cooldown = 0.5f;
    private float timer = 0f;

    void Update()
    {
        timer -= Time.deltaTime;

        // Timer in place because text would change too fast otherwise.
        if (timer <= 0f)
        {
            float current = 0;
            current = (int)(1f / Time.unscaledDeltaTime);
            avgFrameRate = (int)current;
            fpsText.text = "FPS: " + avgFrameRate;

            timer = cooldown;
        }
    }
}
