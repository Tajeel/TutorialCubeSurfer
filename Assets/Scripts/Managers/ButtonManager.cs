using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnButtonPressed_Retry()
    {
        EventManager.TriggerEvent(Constants.Events.LevelRequestParamEnum, Constants.LevelRequest.Retry);
    }
    
    public void OnButtonPressed_Next()
    {
        EventManager.TriggerEvent(Constants.Events.LevelRequestParamEnum, Constants.LevelRequest.GoToNext);
    }
}
