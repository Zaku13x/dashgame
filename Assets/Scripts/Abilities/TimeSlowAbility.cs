using UnityEngine;
using System.Collections;
using System;

public class TimeSlowAbility : Ability
{
    private float oldFixedDeltaTime;

    protected override void OnActivate()
    {
        Time.timeScale = .5f;
        oldFixedDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = .5f * 0.02f;
    }

    protected override void OnDeactivate()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = oldFixedDeltaTime;
    }
}
