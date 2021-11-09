using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text uiTextDiamondsCollectedCount;
    [SerializeField] private Text uiTextCurrentLevel;
    [SerializeField] private Text uiTextDiamondCountLevelCompletePanel;
    [SerializeField] private Text uiTextMultiplierLevelCompletePanel;
    
    [SerializeField] private GameObject animationDiamondCollectedPrefab;
    [SerializeField] private GameObject panelLevelFailed;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelLevelCompleted;
    
    private int _currentDiamondsCollectedCount;

    private void OnEnable()
    {
        EventManager.SubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
        EventManager.SubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.SubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
    }
    
    private void OnDisable()
    {
        EventManager.UnSubscribeEvent(Constants.Events.CollectibleCollidedParamEnum, OnCollectibleCollidedParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.LevelStateParamEnum, OnLevelStateParamEnum);
        EventManager.UnSubscribeEvent(Constants.Events.GameStateParamEnum, OnGameStateParamEnum);
    }

    private void Start()
    {
        _currentDiamondsCollectedCount = PlayerPreferences.PlayerDiamondsCount;
        SetDiamondCountInUI();
        uiTextCurrentLevel.text = $"{PlayerPreferences.PlayerCurrentLevel}";
    }

    private void OnCollectibleCollidedParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.Collectibles.Diamond:
                PlayDiamondCollectedAnimation();
                StartCoroutine(SetDiamondCountAfterAnimationEnd());
                break;
            
            default:
                break;
        }
    }

    private void PlayDiamondCollectedAnimation()
    {
        Instantiate(animationDiamondCollectedPrefab, transform);
    }
    
    private IEnumerator SetDiamondCountAfterAnimationEnd()
    {
        float timeBeforeCountUpdate = 1.1f;
        
        yield return new WaitForSeconds(timeBeforeCountUpdate);
        _currentDiamondsCollectedCount += 1;
        SetDiamondCountInUI();
    }
    
    private void SetDiamondCountInUI()
    {
        uiTextDiamondsCollectedCount.text = $"{_currentDiamondsCollectedCount}";
    }

    private void OnLevelStateParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.LevelState.Completed:
                // AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.LevelWin);
                panelLevelCompleted.SetActive(true);
                break;
            
            case Constants.LevelState.Failed:
                panelLevelFailed.SetActive(true);
                break;
            
            default:
                break;
        }
    }

    private void OnGameStateParamEnum(Enum triggeredValue)
    {
        switch (triggeredValue)
        {
            case Constants.GameState.Active:
                panelStart.SetActive(false);
                break;
            
            default:
                break;
        }
    }

    public void DisplayCurrentLevelDiamonds()
    {
        uiTextDiamondCountLevelCompletePanel.text = $"{GameManager.Instance.currentDiamondsCount}";
    }
    
    public void DisplayMultiplier()
    {
        uiTextMultiplierLevelCompletePanel.text = $"{GameManager.Instance.multiplierFloorMultiplier}x";
    }
}
