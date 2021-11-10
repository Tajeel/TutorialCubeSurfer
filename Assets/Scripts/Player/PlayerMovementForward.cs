using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForward : MonoBehaviour
{
    
    private bool _isMoveable;
    private float _movementSpeed;
    private float _multiplierFloorHeightIncrease;
    private float _rotateDirection;
    private float _rotationSpeed;
    private void Awake()
    {
        _isMoveable = false;
        _movementSpeed = 3f;
        _multiplierFloorHeightIncrease = 0.215f;
        _rotateDirection = 0f;
        _rotationSpeed = 4.5f;
    }

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
        EventManager.SubscribeEvent(Constants.Events.LevelTurnParamEnum, OnLevelTurnParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
        EventManager.UnSubscribeEvent(Constants.Events.LevelTurnParamEnum, OnLevelTurnParamEnum);
    }

    void FixedUpdate()
    {
        if (_isMoveable)
        {
            MoveForward();
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, _rotateDirection, 0), _rotationSpeed * Time.deltaTime);
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

    private void OnLevelTurnParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.LevelTurn.Left:
                _rotateDirection = transform.eulerAngles.y - 90f;
                break;

            case Constants.LevelTurn.Right:
                _rotateDirection = transform.eulerAngles.y + 90f;
                break;

            default:
                break;
        }
    }
}
