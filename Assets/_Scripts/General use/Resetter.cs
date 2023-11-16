using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : TimedAction
{
    private Vector3 initialPosition;

    public override void DoAction()
    {
        transform.position = initialPosition;
    }

    protected override void Awake()
    {
        initialPosition = transform.position;
        base.Awake();
    }
}