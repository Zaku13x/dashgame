using UnityEngine;
using System.Collections;

public class SuperDashAbility : Ability
{
    public float SpeedUpScale;
    public GameObject ParticleEmitter;

    protected override void OnStart()
    {
        ParticleEmitter.SetActive(false);
    }

    protected override void OnActivate()
    {
        ParticleEmitter.SetActive(true);
    }

    protected override void OnDeactivate()
    {
        ParticleEmitter.SetActive(false);
    }
}
