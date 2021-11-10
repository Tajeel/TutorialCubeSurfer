using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTurn : MonoBehaviour
{
    private bool _isTriggered;
    [SerializeField] private Constants.LevelTurn turn;
    private void Start()
    {
        _isTriggered = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isTriggered)
        {
            return;
        }

        if (other.gameObject.layer == Constants.Layers.Player)
        {
            _isTriggered = true;
            EventManager.TriggerEvent(Constants.Events.LevelTurnParamEnum, turn);
        }
    }
}
