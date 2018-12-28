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
    public GameObject impactDecal;

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
            
            RaycastHit hit;
            if (Physics.Raycast(projectileOrigin.position, projectileOrigin.forward, out hit))
            {
                GameObject obj = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
                StartCoroutine(obj.GetComponent<Bullet>().Laser(projectileOrigin.position, hit.point, .1f));
                Instantiate(impactDecal, hit.point, Quaternion.identity);

                hit.collider.gameObject.SendMessageUpwards("TakeHit", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                //fire a default laser for 10 units.
                GameObject obj = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
                StartCoroutine(obj.GetComponent<Bullet>().Laser(projectileOrigin.position, projectileOrigin.forward * 100f, .1f));
            }


        }
    }

    private void OnDisable()
    {
        enabled = false;
    }
}
