using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedAction : MonoBehaviour
{
    [SerializeField]
    private float waitTimeBeforeAction;

    protected virtual void Awake()
    {
        InvokeRepeating(nameof(DoAction), waitTimeBeforeAction, waitTimeBeforeAction);
    }

    public abstract void DoAction();
}

internal interface IActionHolder
{
    Action action { get; set; }
}