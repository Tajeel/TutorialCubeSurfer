using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int nextLevel;
    public Camera playerCamera; // in inspector
    private int _currentLevel;
    [HideInInspector] public int currentDiamondsCount;
    public int multiplierFloorMultiplier;
    
    protected override void Awake()
    {
        base.Awake();
        _currentLevel = PlayerPreferences.PlayerCurrentLevel;
        currentDiamondsCount = 0;
        multiplierFloorMultiplier = 1;
    }

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.LevelRequestParamEnum, OnLevelRequestParamEnum);
        EventManager.SubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.LevelRequestParamEnum, OnLevelRequestParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
    }

    private void OnLevelRequestParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.LevelRequest.Retry:
                PlayerPreferences.PlayerDiamondsCount += currentDiamondsCount;
                SceneManager.LoadScene(_currentLevel);
                break;
            
            case Constants.LevelRequest.GoToNext:
                PlayerPreferences.PlayerCurrentLevel = nextLevel;
                PlayerPreferences.PlayerDiamondsCount += currentDiamondsCount;
                SceneManager.LoadScene(nextLevel);
                break;
            
            default:
                break;
        }
    }
    
    private void OnCollectibleCollidedParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.Collectibles.Diamond:
                currentDiamondsCount += 1;
                break;
            
            default:
                break;
        }
    }
    
    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        currentDiamondsCount *= multiplierFloorMultiplier;
        UIManager.Instance.DisplayCurrentLevelDiamonds();
        UIManager.Instance.DisplayMultiplier();
    }
}
