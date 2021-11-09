using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : Singleton<PlayerPreferences>
{
    private static int _playerDiamondsCount;
    private const string DiamondsCountKey = "DiamondsCount";
    
    private static int _playerCurrentLevel;
    private const string PlayerCurrentLevelKey = "PlayerCurrentLevelKey";
    private void OnEnable()
    {
        ResetPrefs();
        _playerDiamondsCount = PlayerPrefs.GetInt(DiamondsCountKey, 0);
        _playerCurrentLevel = PlayerPrefs.GetInt(PlayerCurrentLevelKey, 1);
    }
    
    private void OnDisable()
    {
        PlayerPrefs.SetInt(DiamondsCountKey, _playerDiamondsCount);
        PlayerPrefs.SetInt(PlayerCurrentLevelKey, _playerCurrentLevel);
    }

    public static int PlayerDiamondsCount
    {
        get => _playerDiamondsCount;
        set => _playerDiamondsCount = value;
    }
    
    public static int PlayerCurrentLevel
    {
        get => _playerCurrentLevel;
        set => _playerCurrentLevel = value;
    }

    private void ResetPrefs()
    {
        PlayerPrefs.SetInt(DiamondsCountKey, 0);
        PlayerPrefs.SetInt(PlayerCurrentLevelKey, 1);
    }
}
