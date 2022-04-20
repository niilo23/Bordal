using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFlareDistanceFix : MonoBehaviour
{
    private float Size;
    public LensFlare Flare;
    public float BrightnessModifier = 2;
    public float CutOff = 0.15f;

    void Start()
    {
        if (Flare == null)
        {
            Flare = GetComponent<LensFlare>();
        }

        if (Flare == null)
        {
            Debug.LogWarning("No LensFlare on " + name + ", destroying.", this);
            Destroy(this);
            return;
        }

        Size = Flare.brightness;
    }

    void Update()
    {
        float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, Camera.main.transform.position));
        Flare.brightness = Size / ratio * BrightnessModifier;
        //Debug.Log("Flare brightness: " + Flare.brightness);

        if (Flare.brightness <= CutOff)
        {
            Flare.enabled = false;
        }
        else
        {
            Flare.enabled = true;
        }
    }
}
