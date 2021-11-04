using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class FloatUnityEvents : UnityEvent<float>
{
}

public class IntUnityEvents : UnityEvent<int>
{
}

public class EnumUnityEvents : UnityEvent<Enum>
{
}

public class BoolUnityEvents : UnityEvent<bool>
{
}

public class GameObjectUnityEvents : UnityEvent<GameObject>
{
}

public class EventManager : Singleton<EventManager>
{
   protected override void Awake()
   {
      base.Awake();
      Instance._voidUnityEvents = new Dictionary<string, UnityEvent>();
      Instance._floatUnityEvents = new Dictionary<string, UnityEvent<float>>();
      Instance._intUnityEvents = new Dictionary<string, UnityEvent<int>>();
      Instance._boolUnityEvents = new Dictionary<string, UnityEvent<bool>>();
      Instance._gameObjectUnityEvents = new Dictionary<string, UnityEvent<GameObject>>();
      Instance._enumUnityEvents = new Dictionary<string, UnityEvent<Enum>>();
   }

   #region VoidUnityEvents
   
   private Dictionary<string, UnityEvent> _voidUnityEvents;

   public static void TriggerEvent(string eventName)
   {
      if (Instance._voidUnityEvents.TryGetValue(eventName, out UnityEvent thisEvent))
      {
         thisEvent.Invoke();
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction listener)
   {
      if (Instance._voidUnityEvents.TryGetValue(eventName, out UnityEvent thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new UnityEvent();
         thisEvent.AddListener(listener);
         Instance._voidUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction listener)
   {
      if (Instance._voidUnityEvents.TryGetValue(eventName, out UnityEvent thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
   
   #region FloatUnityEvents
   
   private Dictionary<string, UnityEvent<float>> _floatUnityEvents;

   public static void TriggerEvent(string eventName, float triggerValue)
   {
      if (Instance._floatUnityEvents.TryGetValue(eventName, out UnityEvent<float> thisEvent))
      {
         thisEvent.Invoke(triggerValue);
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction<float> listener)
   {
      if (Instance._floatUnityEvents.TryGetValue(eventName, out UnityEvent<float> thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new FloatUnityEvents();
         thisEvent.AddListener(listener);
         Instance._floatUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction<float> listener)
   {
      if (Instance._floatUnityEvents.TryGetValue(eventName, out UnityEvent<float> thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
   
   #region IntUnityEvents
   
   private Dictionary<string, UnityEvent<int>> _intUnityEvents;

   public static void TriggerEvent(string eventName, int triggerValue)
   {
      if (Instance._intUnityEvents.TryGetValue(eventName, out UnityEvent<int> thisEvent))
      {
         thisEvent.Invoke(triggerValue);
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction<int> listener)
   {
      if (Instance._intUnityEvents.TryGetValue(eventName, out UnityEvent<int> thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new IntUnityEvents();
         thisEvent.AddListener(listener);
         Instance._intUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction<int> listener)
   {
      if (Instance._intUnityEvents.TryGetValue(eventName, out UnityEvent<int> thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
   
   #region BoolUnityEvents
   
   private Dictionary<string, UnityEvent<bool>> _boolUnityEvents;

   public static void TriggerEvent(string eventName, bool triggerValue)
   {
      if (Instance._boolUnityEvents.TryGetValue(eventName, out UnityEvent<bool> thisEvent))
      {
         thisEvent.Invoke(triggerValue);
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction<bool> listener)
   {
      if (Instance._boolUnityEvents.TryGetValue(eventName, out UnityEvent<bool> thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new BoolUnityEvents();
         thisEvent.AddListener(listener);
         Instance._boolUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction<bool> listener)
   {
      if (Instance._boolUnityEvents.TryGetValue(eventName, out UnityEvent<bool> thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
   
   #region GameObjectUnityEvents
   
   private Dictionary<string, UnityEvent<GameObject>> _gameObjectUnityEvents;

   public static void TriggerEvent(string eventName, GameObject triggerValue)
   {
      if (Instance._gameObjectUnityEvents.TryGetValue(eventName, out UnityEvent<GameObject> thisEvent))
      {
         thisEvent.Invoke(triggerValue);
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction<GameObject> listener)
   {
      if (Instance._gameObjectUnityEvents.TryGetValue(eventName, out UnityEvent<GameObject> thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new GameObjectUnityEvents();
         thisEvent.AddListener(listener);
         Instance._gameObjectUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction<GameObject> listener)
   {
      if (Instance._gameObjectUnityEvents.TryGetValue(eventName, out UnityEvent<GameObject> thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
   
   #region EnumUnityEvents
   
   private Dictionary<string, UnityEvent<Enum>> _enumUnityEvents;

   public static void TriggerEvent(string eventName, Enum triggerValue)
   {
      if (Instance._enumUnityEvents.TryGetValue(eventName, out UnityEvent<Enum> thisEvent))
      {
         thisEvent.Invoke(triggerValue);
      }
   }

   public static void SubscribeEvent(string eventName, UnityAction<Enum> listener)
   {
      if (Instance._enumUnityEvents.TryGetValue(eventName, out UnityEvent<Enum> thisEvent))
      {
         thisEvent.AddListener(listener);
      }

      else
      {
         thisEvent = new EnumUnityEvents();
         thisEvent.AddListener(listener);
         Instance._enumUnityEvents.Add(eventName, thisEvent);
      }
   }
   
   public static void UnSubscribeEvent(string eventName, UnityAction<Enum> listener)
   {
      if (Instance._enumUnityEvents.TryGetValue(eventName, out UnityEvent<Enum> thisEvent))
      {
         thisEvent.RemoveListener(listener);
      }
   }
   
   #endregion
}
