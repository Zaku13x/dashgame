using UnityEngine;
using System.Collections;

public class MegaLaserAbility : Ability
{
    public GameObject Laser;

    private Object currentLaser;

    protected override void OnActivate()
    {
        var position = this.GetComponent<Transform>().position;

        position.x += .75f;

        currentLaser = GameObject.Instantiate(this.Laser, position, new Quaternion(), this.GetComponent<Transform>());
    }

    protected override void OnDeactivate()
    {
        GameObject.Destroy(currentLaser);
        currentLaser = null;
    }
}
