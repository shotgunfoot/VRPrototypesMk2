using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LazerGun : MonoBehaviour
{
    //The AudioSource component attached to this gameobject
    public AudioSource AudioSource;
    //The AudioClip 
    public AudioClipCollection AudioClipCollection;
    //The origin for where the bullets spawn
    public Transform projectileOrigin;
    public GameObject projectile;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();        
    }

    private void Update()
    {
        bool trigger = SteamVR_Input._default.inActions.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.Any);

        if (trigger)
        {
            AudioSource.PlayOneShot(AudioClipCollection.clips[0]);
            Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
        }
    }

    private void OnDisable()
    {
        enabled = false;
    }
}
