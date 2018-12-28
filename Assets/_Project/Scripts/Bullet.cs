using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    public IEnumerator Laser(Vector3 origin, Vector3 target, float lerpTime = 1f)
    {
        Vector3 lerpPos;
        float lerpTimer = 0;        
        LineRenderer ren = GetComponent<LineRenderer>();        
        ren.SetPosition(1, target);

        while (lerpTimer < lerpTime)
        {
            float lerpPercent = lerpTimer / lerpTime;
            lerpTimer += Time.deltaTime;
            lerpPos = Vector3.Lerp(origin, target, lerpPercent);            
            ren.SetPosition(0, lerpPos);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {       
        GetComponent<SphereCollider>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
    }
}
