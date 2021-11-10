using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierFloor : MonoBehaviour
{
    public int floorMultiplier;
    [SerializeField] private Text uiTextFloorMultiplier;

    private void Start()
    {
        uiTextFloorMultiplier.text = $"{floorMultiplier}x";
    }
}
