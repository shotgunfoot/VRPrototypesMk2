using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ItemPickup : MonoBehaviour
{

    public bool RequirePressToTake;

    private void OnHandHoverBegin(Hand hand)
    {

    }

    private void HandHoverUpdate(Hand hand)
    {
        if (RequirePressToTake)
        {
            GrabTypes startingGrab = hand.GetGrabStarting();

            //this means any grabtype grabs it
            if (startingGrab != GrabTypes.None)
            {
                //AttachObjectToHand();
                Debug.Log("any!");
            }

            //this means a pinch grabtype grabs it
            if(startingGrab == GrabTypes.Pinch)
            {
                //AttachObjectToHand();
                Debug.Log("pinched");
            }

            //this means a grip grabtype grabs it
            if(startingGrab == GrabTypes.Grip)
            {
                //AttachObjectToHand();
                Debug.Log("gripped!");
            }
        }
    }

    private void AttachObjectToHand()
    {
        Debug.Log("attach to hand!");
    }

}
