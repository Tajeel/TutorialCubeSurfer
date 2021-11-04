using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool _isTriggered = false;
    private void OnCollisionEnter(Collision other)
    {
        if (_isTriggered)
        {
            return;
        }

        if (other.gameObject.layer == Constants.Layers.Player || other.gameObject.layer == Constants.Layers.LevelFinisher)
        {
            _isTriggered = true;
            Handheld.Vibrate();
            EventManager.TriggerEvent(Constants.Events.LevelStateParamEnum, Constants.LevelState.Completed);
        }
    }
}
