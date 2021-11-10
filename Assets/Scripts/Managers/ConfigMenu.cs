using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    [SerializeField] private Slider playerMovementSpeed;
    [SerializeField] private Slider playerCameraDistance;
    [SerializeField] private Slider playerCameraRotationVertical;
    [SerializeField] private Slider playerCameraRotationHorizontal;

    private void OnEnable()
    {
        playerMovementSpeed.onValueChanged.AddListener (delegate {UpdatePlayerMovementSpeed();});
        playerCameraDistance.onValueChanged.AddListener (delegate {UpdatePlayerCameraDistance();});
    }
    
    private void OnDisable()
    {
        playerMovementSpeed.onValueChanged.RemoveListener(delegate {UpdatePlayerMovementSpeed();});
        playerCameraDistance.onValueChanged.RemoveListener(delegate {UpdatePlayerCameraDistance();});
    }

    private void Awake()
    {
        SetMovementSpeedSlider();
        SetCameraDistanceSlider();
    }

    private void SetMovementSpeedSlider()
    {
        int speedFactor = 3;
        // 3 factor of original speed
        playerMovementSpeed.maxValue = GameManager.Instance.playerMovementSpeed * speedFactor;
        playerMovementSpeed.minValue = GameManager.Instance.playerMovementSpeed / speedFactor;
        playerMovementSpeed.value = GameManager.Instance.playerMovementSpeed;
    }

    private void SetCameraDistanceSlider()
    {
        int distanceFactor = 2;
        // 2 factor of original distance
        playerCameraDistance.maxValue = Mathf.Abs(GameManager.Instance.playerCamera.transform.localPosition.z * distanceFactor);
        playerCameraDistance.minValue = Mathf.Abs(GameManager.Instance.playerCamera.transform.localPosition.z);
        playerCameraDistance.value = Mathf.Abs(GameManager.Instance.playerCamera.transform.localPosition.z);
    }

    private void UpdatePlayerMovementSpeed()
    {
        GameManager.Instance.playerMovementSpeed = playerMovementSpeed.value;
    }

    private void UpdatePlayerCameraDistance()
    {
        GameManager.Instance.playerCamera.transform.localPosition = new Vector3(
            GameManager.Instance.playerCamera.transform.localPosition.x,
            GameManager.Instance.playerCamera.transform.localPosition.y, -playerCameraDistance.value);
    }
}
