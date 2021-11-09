using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerCubeStackHandler : Singleton<PlayerCubeStackHandler>
{
    [SerializeField] private CubeStack playerCubeStack;
    private bool _isInvulnerable;
    private float _invulerabilityDuration;
    private bool _isActive;
    private void Start()
    {
        _isActive = true;
        _isInvulnerable = false;
        _invulerabilityDuration = 0.15f;
    }
    
    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (!_isActive)
        {
            return;
        }

        if (other.gameObject.layer == Constants.Layers.MultiplierFloor)
        {
            if (playerCubeStack.StackHeight <= 1)
            {
                EventManager.TriggerEvent(Constants.Events.LevelStateParamEnum, Constants.LevelState.Completed);
                playerCubeStack.RemoveCubes(1, true, 2f);
            }
            else
            {
                GameManager.Instance.multiplierFloorMultiplier =
                    other.transform.GetComponent<MultiplierFloor>().floorMultiplier;
                other.transform.GetComponent<BoxCollider>().enabled = false;
                playerCubeStack.RemoveCubes(1, true, 2f);
                EventManager.TriggerEvent(Constants.Events.CubesRemovedFromPlayerParamInt, 1);
                EventManager.TriggerEvent(Constants.Events.CollidedWithMultiplierFloorParamVoid);
            }
        }
        else if (other.gameObject.layer == Constants.Layers.Barrier)
        {
            if (_isInvulnerable)
            {
                return;
            }

            StartCoroutine(TriggerInvulnerability());
            Handheld.Vibrate();
            // interact with barriers
            if (other.transform.CompareTag(Constants.Tags.Wall))
            {
                CubeStack barrierCubeStack = other.transform.GetComponent<CubeStack>();
                if (playerCubeStack.StackHeight <= barrierCubeStack.StackHeight)
                {
                    EventManager.TriggerEvent(Constants.Events.LevelStateParamEnum, Constants.LevelState.Failed);
                }
                else
                {
                    playerCubeStack.RemoveCubes(barrierCubeStack.StackHeight);
                    EventManager.TriggerEvent(Constants.Events.CubesRemovedFromPlayerParamInt, barrierCubeStack.StackHeight);
                }
            }
            else
            {
                // its lava floor
                // AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.LavaBurn);
                if (playerCubeStack.StackHeight <= 1)
                {
                    EventManager.TriggerEvent(Constants.Events.LevelStateParamEnum, Constants.LevelState.Failed);
                }
                else
                {
                    playerCubeStack.RemoveCubes(1, true);
                    EventManager.TriggerEvent(Constants.Events.CubesRemovedFromPlayerParamInt, 1);
                }
            }
        }
        else if (other.gameObject.layer == Constants.Layers.Collectible)
        {
            // interact with collectibles
            other.transform.GetComponent<BoxCollider>().enabled = false;
            if (other.transform.CompareTag(Constants.Tags.SurfingCube))
            {
                AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.SurfaceCubeCollected);
                CubeStack surfingCubeStack = other.transform.GetComponent<CubeStack>();
                EventManager.TriggerEvent(Constants.Events.CubesAddedToPlayerParamInt, surfingCubeStack.StackHeight);
                playerCubeStack.AddCubes(surfingCubeStack.StackHeight);
                Destroy(other.gameObject);
            }
            
            else if (other.transform.CompareTag(Constants.Tags.Diamond))
            {
                AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.DiamondCollected);
                EventManager.TriggerEvent(Constants.Events.CollectibleCollidedParamEnum, Constants.Collectibles.Diamond);
                EventManager.TriggerEvent(Constants.Events.CollectibleCollidedParamGameObject, other.gameObject);
                Destroy(other.gameObject);
            }
            
            else if (other.transform.CompareTag(Constants.Tags.Magnet))
            {
                AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.MagnetPick);
                Handheld.Vibrate();
                EventManager.TriggerEvent(Constants.Events.CollectibleCollidedParamEnum, Constants.Collectibles.Magnet);
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator TriggerInvulnerability()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(_invulerabilityDuration);
        _isInvulnerable = false;
    }
    
    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        _isActive = false;
    }
}
