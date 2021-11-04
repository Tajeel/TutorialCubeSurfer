using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationView : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform center;
    private Vector3 _desiredPosition;
    private float _radius;
    private float _radiusSpeed;
    private float _rotationSpeed;
    private bool _isActive;
    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        _radius = 3.0f;
        _radiusSpeed = 0.5f;
        _rotationSpeed = 40f;
        _isActive = false;
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.LevelState.Completed:
                _isActive = true;
                break;
            
            default:
                break;
        }
    }
    private void Start () {
        center = cube.transform;
        transform.position = (transform.position - center.position).normalized * _radius + center.position;
    }
     
    private void Update () {
        if (_isActive)
        {
            transform.RotateAround (center.position, Vector3.up, _rotationSpeed * Time.deltaTime);
            _desiredPosition = (transform.position - center.position).normalized * _radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, _desiredPosition, Time.deltaTime * _radiusSpeed);
        }
    }
}
