using UnityEngine;
using System.Collections;

public class TimeSlowPickup : Pickup
{
    protected override void OnPickUp(GameObject ship)
    {
        ship.GetComponent<SuperDashAbility>().Deactivate();
        ship.GetComponent<MegaLaserAbility>().Deactivate();

        ship.GetComponent<SuperDashAbility>().enabled = false;
        ship.GetComponent<MegaLaserAbility>().enabled = false;
        ship.GetComponent<TimeSlowAbility>().enabled = true;
    }
}
