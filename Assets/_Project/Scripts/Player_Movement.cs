using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Player_Movement : MonoBehaviour
{

    public float walk;
    public float run;
    public Camera VRCam;

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 axis = SteamVR_Input._default.inActions.TouchpadTouch.GetAxis(SteamVR_Input_Sources.Any);

        Vector3 direction = new Vector3(axis.x, 0, axis.y);

        Vector3 camForward = VRCam.transform.forward;
        Vector3 camRight = VRCam.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 desiredDirection = camForward * axis.y + camRight * axis.x;

        float speed = SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.Any) ? run : walk;

        transform.Translate(desiredDirection * speed * Time.deltaTime);

    }
}
