using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    public bool cursorLocked = true;

    void Start()
    {
        ToggleCursor(true);
    }

    public void ToggleCursor(bool cursorLocked)
    {
        if (cursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else if (cursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }   
    }
}
