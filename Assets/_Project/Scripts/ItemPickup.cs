using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ItemPickup : MonoBehaviour
{

    [EnumFlags]
    public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;
    public Transform AttachPoint;

    private bool held = false;
    private LazerGun gun;

    private void Start()
    {
        gun = GetComponent<LazerGun>();
    }

    private void OnHandHoverBegin(Hand hand)
    {

    }

    private void HandHoverUpdate(Hand hand)
    {

        if (!held)
        {
            GrabTypes startingGrab = hand.GetGrabStarting();

            ////this means any grabtype grabs it
            // if (startingGrab != GrabTypes.None)
            // {
            //     //AttachObjectToHand();
            //     Debug.Log("any!");
            // }

            //this means a pinch grabtype grabs it
            //if(startingGrab == GrabTypes.Pinch)
            //{
            //    //AttachObjectToHand();                
            //}

            //this means a grip grabtype grabs it
            if (startingGrab == GrabTypes.Grip)
            {
                AttachObjectToHand(hand, startingGrab);
            }
        }
    }

    private void HandAttachedUpdate(Hand hand)
    {
        if (held)
        {
            GrabTypes startingGrab = hand.GetGrabStarting();

            ////this means any grabtype grabs it
            // if (startingGrab != GrabTypes.None)
            // {
            //     //AttachObjectToHand();
            //     Debug.Log("any!");
            // }

            //this means a pinch grabtype grabs it
            //if(startingGrab == GrabTypes.Pinch)
            //{
            //    //AttachObjectToHand();                
            //}

            //this means a grip grabtype grabs it
            if (startingGrab == GrabTypes.Grip)
            {
                DropAttachedObject(hand);
            }
        }
    }

    private void SetRotationAndPosition()
    {
        transform.localPosition = AttachPoint.localPosition;
        transform.localRotation = AttachPoint.localRotation;
    }

    private void AttachObjectToHand(Hand hand, GrabTypes grabType)
    {
        held = true;
        hand.AttachObject(gameObject, grabType, attachmentFlags);
        SetRotationAndPosition();
        gun.enabled = true;
    }

    private void DropAttachedObject(Hand hand)
    {
        held = false;
        hand.DetachObject(gameObject);
        gun.enabled = false;
    }

}
