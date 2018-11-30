using UnityEngine;
using System.Collections;

public class SuperDashBackgroundParticleSpeedManager : MonoBehaviour
{
    private GameObject ship;
    private ParticleSystem particles;

    private float originalRateScale;
    //private float originalMinParticleVelocity;
    //private float originalMaxParticleVelocity;

    // Use this for initialization
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        particles = this.GetComponent<ParticleSystem>();

        originalRateScale = particles.emission.rate.curveScalar;

        //originalMinParticleVelocity = particles.velocityOverLifetime.x.constantMin;
        //originalMaxParticleVelocity = particles.velocityOverLifetime.x.constantMax;
    }

    // Update is called once per frame
    void Update()
    {
        var superDashAbility = ship.GetComponent<SuperDashAbility>();
        if(superDashAbility != null)
        {
            if (superDashAbility.IsActive)
            {
                var velocity = particles.velocityOverLifetime;
                var xCurve = velocity.x;
                xCurve.curveScalar = superDashAbility.SpeedUpScale;
                velocity.x = xCurve;

                var emission = particles.emission;
                var emissionCurve = emission.rate;
                emissionCurve.curveScalar = originalRateScale * superDashAbility.SpeedUpScale;
                emission.rate = emissionCurve;
            }
            else
            {
                var velocity = particles.velocityOverLifetime;
                var xCurve = velocity.x;
                xCurve.curveScalar = 1;
                velocity.x = xCurve;

                var emission = particles.emission;
                var emissionCurve = emission.rate;
                emissionCurve.curveScalar = originalRateScale;
                emission.rate = emissionCurve;
            }
        }
    }
}
