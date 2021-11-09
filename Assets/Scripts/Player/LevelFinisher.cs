using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    private bool _isActive;
    
    private void Start()
    {
        _isActive = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isActive)
        {
            return;
        }

        if (other.gameObject.layer == Constants.Layers.Barrier)
        {
            Handheld.Vibrate();
            // interact with barriers
            if (other.transform.CompareTag(Constants.Tags.Wall))
            {
                AudioManager.Instance.PlaySound((int) AudioManager.AudioClipsEnum.CollidedWithWall);
                EventManager.TriggerEvent(Constants.Events.LevelStateParamEnum, Constants.LevelState.Failed);
                _isActive = false;
            }
        }
    }
}