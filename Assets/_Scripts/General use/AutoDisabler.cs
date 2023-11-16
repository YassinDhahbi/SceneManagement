using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisabler : TimedAction
{
    public override void DoAction()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        gameObject.SetActive(true);
    }
}