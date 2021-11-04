using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem surfingCubeSelected;
    [SerializeField] private Transform playerAvatar;
    [SerializeField] private GameObject magnetPrefab;
    [SerializeField] private Transform trail;
    private float _heightFactor = 0.215f;
    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.CubesAddedToPlayerParamInt, OnCubesAddedToPlayerParamInt);
        EventManager.SubscribeEvent(Constants.Events.CubesRemovedFromPlayerParamInt, CubesRemovedFromPlayerParamInt);
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.CubesAddedToPlayerParamInt, OnCubesAddedToPlayerParamInt);
        EventManager.UnSubscribeEvent(Constants.Events.CubesRemovedFromPlayerParamInt, CubesRemovedFromPlayerParamInt);
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
    }

    private void OnCubesAddedToPlayerParamInt(int triggeredValue)
    {
        surfingCubeSelected.Play();
        animator.SetTrigger(Constants.PlayerAnimator.Jumping);
        Vector3 position = playerAvatar.position;
        position = new Vector3(position.x, position.y + (triggeredValue * _heightFactor), position.z);
        playerAvatar.position = position;
    }

    private void CubesRemovedFromPlayerParamInt(int triggeredValue)
    {
        surfingCubeSelected.Play();
        animator.SetTrigger(Constants.PlayerAnimator.Spin);
        Vector3 position = playerAvatar.position;
        position = new Vector3(position.x, position.y - (triggeredValue * _heightFactor), position.z);
        playerAvatar.position = position;
    }
    
    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.LevelState.Completed:
                animator.SetTrigger(Constants.PlayerAnimator.WaveDance);
                break;
            
            case Constants.LevelState.Failed:
                animator.SetTrigger(Constants.PlayerAnimator.Death);
                break;
            
            default:
                break;
        }
    }
    
    private void OnCollectibleCollidedParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.Collectibles.Magnet:
                EnableMagnet();
                break;
            
            default:
                break;
        }
    }

    private void EnableMagnet()
    {
        Instantiate(magnetPrefab, trail);
    }
}
