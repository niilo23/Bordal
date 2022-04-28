using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool PickedUp = false;
    private Transform pickedUpObject;
    private Rigidbody rb;
    private Transform PickupDestination;

    [Tooltip("Object which the picked up object will be parented to.")]
    public Transform boxParent;

    void Start()
    {
        PickupDestination = GameObject.Find("PickupDestination").transform;
    }

    void LateUpdate()
    {
        if(PickedUp == true)
        {
            this.transform.position = PickupDestination.position;
        }
    }

    // t‰m‰ disablee painovoiman objektista, jota pidet‰‰n k‰dess‰, ettei se suoraan putoa.
    private void OnMouseDown()
    {
        if(gameObject.tag == "Movable")
        { 
            PickedUp = true;

            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;

            rb = this.GetComponent<Rigidbody>();
            pickedUpObject = this.transform;
            pickedUpObject.transform.parent = GameObject.Find("PickupDestination").transform;

            // Freeze rigidbody rotation & constraints so objects don't spin while held and conserve velocity when dropped.
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            pickedUpObject.transform.rotation = new Quaternion(15, 0, 0, 0);
        }
    }

    // t‰m‰ palauttaa painovoiman, kun sit‰ ei en‰‰n pidet‰ k‰dess‰.
    private void OnMouseUp()
    {
        // Reverses all steps above

        PickedUp = false;
        pickedUpObject.parent = boxParent;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;

        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
