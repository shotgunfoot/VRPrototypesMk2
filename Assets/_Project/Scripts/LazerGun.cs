using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LazerGun : MonoBehaviour
{
    private void Update()
    {
        bool trigger = SteamVR_Input._default.inActions.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.Any);

        if (trigger)
        {
            Debug.Log("Pew!");
        }
    }
}
