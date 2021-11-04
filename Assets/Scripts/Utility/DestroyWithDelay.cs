using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    [SerializeField] private float delayBeforeDestroy;

    private void OnEnable()
    {
        Destroy(gameObject, delayBeforeDestroy);
    }
}
