using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 _direction;
    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _direction = UIManager.Instance.spriteDiamondUI.position - transform.position;
    }
}
