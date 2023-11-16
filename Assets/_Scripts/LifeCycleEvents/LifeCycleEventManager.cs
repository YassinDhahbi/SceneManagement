using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YassinUtils.LifeCycleEvents
{
    public class LifeCycleEventManager : MonoBehaviour
    {
        #region Events Section

        [Header("Events Section")]
        [SerializeField]
        private List<LifeCycleEvent> lifeCycleEvents = new List<LifeCycleEvent>();

        #endregion Events Section

        #region MonoBehaviour Section

        private void Awake()
        {
            ExecuteLifeCycleEvents(LifeCycle.Awake);
        }

        private void OnEnable()
        {
            ExecuteLifeCycleEvents(LifeCycle.OnEnable);
        }

        private void Start()
        {
            ExecuteLifeCycleEvents(LifeCycle.Start);
        }

        private void OnDisable()
        {
            ExecuteLifeCycleEvents(LifeCycle.OnDisable);
        }

        private void OnDestroy()
        {
            ExecuteLifeCycleEvents(LifeCycle.OnDestroy);
        }

        #endregion MonoBehaviour Section

        #region Methods

        private void ExecuteLifeCycleEvents(LifeCycle lifeCycle)
        {
            foreach (LifeCycleEvent lifeCycleEvent in lifeCycleEvents)
            {
                if (lifeCycleEvent.CompareLifeCycle(lifeCycle))
                {
                    lifeCycleEvent.RaiseEvent();
                }
            }
        }

        #endregion Methods
    }

    [Serializable]
    public class LifeCycleEvent
    {
        public LifeCycle lifeCycle;

        [SerializeField]
        private UnityEvent lifeCycleEvent;

        public bool CompareLifeCycle(LifeCycle targetLifeCycle)
        {
            GUI.backgroundColor = Color.red;
            return lifeCycle == targetLifeCycle;
        }

        public void RaiseEvent()
        {
            lifeCycleEvent?.Invoke();
        }
    }

    public enum LifeCycle
    {
        Awake,
        OnEnable,
        Start,
        OnDisable,
        OnDestroy
    }
}