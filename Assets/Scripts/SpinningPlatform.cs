using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    private void FixedUpdate ()
    {
        transform.Rotate (0f, rotationSpeed * Time.fixedDeltaTime, 0f);
    }
}
