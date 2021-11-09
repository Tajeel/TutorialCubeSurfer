using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float hoverSpeed;
    [SerializeField] private float timeToHover;
    private bool _hoverUp;

    private void FixedUpdate()
    {
        StartCoroutine(_hoverUp ? HoverUp() : HoverDown());
    }

    private IEnumerator HoverUp()
    {
        transform.Translate(Vector3.up * hoverSpeed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(timeToHover);
        _hoverUp = false;
    }
    
    private IEnumerator HoverDown()
    {
        transform.Translate(Vector3.down * hoverSpeed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(timeToHover);
        _hoverUp = true;
    }
}
