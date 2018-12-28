using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float SecondsUntilDestruction = 5f;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        if (timer > SecondsUntilDestruction)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

}
