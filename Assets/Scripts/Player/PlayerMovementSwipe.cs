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
        _movementSpeedX = 0.03f;
        _minX = -0.5f;
        _maxX = 0.5f;
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
        Vector3 position = transform.position;
        float xPos = position.x - _movementSpeedX;

        xPos = Mathf.Clamp(xPos, _minX, _maxX);
        position = new Vector3(xPos, position.y, position.z);
        transform.position = position;
    }
    
    private void MovePlayerToRight()
    {
        Vector3 position = transform.position;
        float xPos = position.x + _movementSpeedX;
        
        xPos = Mathf.Clamp(xPos, _minX, _maxX);
        position = new Vector3(xPos, position.y, position.z);
        transform.position = position;
    }

    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        _isMoveable = false;
    }
}
