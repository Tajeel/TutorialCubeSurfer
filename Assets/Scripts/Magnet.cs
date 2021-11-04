using System;
using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float activeDuration;
    private float _pullForce;
    private void Start()
    {
        _pullForce = 2f;
        Destroy(gameObject, activeDuration);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == Constants.Layers.Collectible)
        {
            // attract them
            Vector3 direction = transform.position - other.transform.position;
            direction.Normalize();
            other.transform.Translate(direction * _pullForce * Time.deltaTime);
        }
    }
}
