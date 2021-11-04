using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishLine;

    [SerializeField] private Slider slider;

    private bool _shouldUpdate;

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid, OnCollidedWithMultiplierFloorParamVoid);
    }

    private void Start()
    {
        _shouldUpdate = true;
        ResetLevelProgress();
    }

    private void FixedUpdate()
    {
        if (_shouldUpdate)
        {
            UpdateLevelProgressBar();
        }
    }

    private void UpdateLevelProgressBar()
    {
        slider.value = slider.maxValue - Vector3.Distance(player.position, finishLine.position);
    }

    private void ResetLevelProgress()
    {
        slider.maxValue = Vector3.Distance(player.position, finishLine.position);
        slider.value = 0f;
    }

    private void OnCollidedWithMultiplierFloorParamVoid()
    {
        _shouldUpdate = false;
        slider.value = slider.maxValue;
    }
}
