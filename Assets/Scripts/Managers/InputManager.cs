using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private float _playerMovePositionX;
    private float _startTouchX;
    private bool _isTouched;
    private bool _isGameStarted = false;
    public float PlayerMovePositionX
    {
        get => _playerMovePositionX;
        private set => _playerMovePositionX = value;
    }

    private void Start()
    {
        _isTouched = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isGameStarted)
            {
                _isGameStarted = true;
                EventManager.TriggerEvent(Constants.Events.GameStateParamEnum, Constants.GameState.Active);
            }

            _isTouched = true;
            _startTouchX = Input.mousePosition.x;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _isTouched = false;
            _startTouchX = 0f;
        }

        if (_isTouched)
        {
            if (_startTouchX > Input.mousePosition.x)
            {
                _playerMovePositionX = -1f;
            } else if (_startTouchX < Input.mousePosition.x)
            {
                _playerMovePositionX = 1f;
            }
            else
            {
                _playerMovePositionX = 0f;
            }
        }
        else
        {
            _playerMovePositionX = 0f;
        }
    }
}
