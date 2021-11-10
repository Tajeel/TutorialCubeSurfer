using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwipe : MonoBehaviour
{
    private float _movementSpeedX;
    private bool _isMoveable;
    private float _minX;
    private float _maxX;
    private void Awake()
    {
        _isMoveable = true;
        _movementSpeedX = 3f;
        _minX = -1.667f;
        _maxX = 1.667f;
    }

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    void FixedUpdate()
    {
        if (_isMoveable)
        {
            MoveInXDirection();
        }
    }
    
    private void MoveInXDirection()
    {
        if (InputManager.Instance.PlayerMovePositionX < 0f)
        {
            MovePlayerToLeft();
        }
        
        else if (InputManager.Instance.PlayerMovePositionX > 0f)
        {
            MovePlayerToRight();
        }
    }

    private void MovePlayerToLeft()
    {
        transform.Translate(Vector3.left * _movementSpeedX * Time.fixedDeltaTime);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, _minX, _maxX), 0, 0);
    }
    
    private void MovePlayerToRight()
    {
        transform.Translate(Vector3.right * _movementSpeedX * Time.fixedDeltaTime);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, _minX, _maxX), 0, 0);
    }

    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        _isMoveable = false;
    }
}
