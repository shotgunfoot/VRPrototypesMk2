using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{    
    public void TakeHit()
    {
        BlowUp();
    }

    public GameObject Explosion;
    public void BlowUp()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }    
}
