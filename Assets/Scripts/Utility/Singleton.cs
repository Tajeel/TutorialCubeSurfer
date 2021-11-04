using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance)
            {
                return _instance;
            }
            
            _instance = Object.FindObjectOfType<T>();
            
            if (!_instance)
            {
                Debug.LogError($"There needs to be an active {typeof(T)} in the scene.");
            }

            return _instance;
        }
        
        private set => _instance = value;
    }

    protected virtual void Awake()
    {
        if (!_instance)
        {
            _instance = this as T;
        }
        
        else
        {
            Object.Destroy(this as T);
        }
    }
}
