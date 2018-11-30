using UnityEngine;
using System.Collections;
using System;

public class MegaLaserPickup : Pickup
{
    protected override void OnPickUp(GameObject ship)
    {
        ship.GetComponent<SuperDashAbility>().Deactivate();
        ship.GetComponent<TimeSlowAbility>().Deactivate();

        ship.GetComponent<SuperDashAbility>().enabled = false;
        ship.GetComponent<TimeSlowAbility>().enabled = false;
        ship.GetComponent<MegaLaserAbility>().enabled = true;
    }
}
