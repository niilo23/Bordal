using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotate : MonoBehaviour
{
    public float rotSpd = 0.43f;
    public float amplitude = 0.2f;
    public float frequency = 1f;

    public bool spinX;
    public bool spinY;
    public bool spinZ;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

        if (spinX) SpinAroundX();
        if (spinZ) SpinAroundZ();
        if (spinY) SpinAroundY();

    }

    void SpinAroundX()
    {
        // Spins object around Y axis
        transform.Rotate(rotSpd, 0, 0 * Time.deltaTime);
        transform.position = tempPos;
    }

    void SpinAroundY()
    {
        // Spins object around Y axis
        transform.Rotate(0, rotSpd, 0 * Time.deltaTime);
        transform.position = tempPos;
    }

    void SpinAroundZ()
    {
        // Spins object around Y axis
        transform.Rotate(0, 0, rotSpd * Time.deltaTime);
        transform.position = tempPos;
    }
}
