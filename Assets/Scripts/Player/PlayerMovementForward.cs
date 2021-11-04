using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForward : MonoBehaviour
{
    
    private bool _isMoveable;
    private float _movementSpeed;
    private float _multiplierFloorHeightIncrease;
    
    private void Awake()
    {
        _isMoveable = false;
        _movementSpeed = 3f;
        _multiplierFloorHeightIncrease = 0.215f;
    }

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
    }

    void FixedUpdate()
    {
        if (_isMoveable)
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _movementSpeed);
    }
    
    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        _isMoveable = false;
    }
    
    private void OnGameStateParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.GameState.Active:
                _isMoveable = true;
                break;
            
            case Constants.GameState.Paused:
                _isMoveable = false;
                break;
            
            default:
                break;
        }
    }

    private void OnCollidedWithMultiplierFloorParamVoid()
    {
        Vector3 position = transform.position;
        position = new Vector3(position.x, position.y + _multiplierFloorHeightIncrease,
            position.z);
        transform.position = position;
    }
}
