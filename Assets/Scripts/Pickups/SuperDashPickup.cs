using UnityEngine;
using System.Collections;

public class SuperDashPickup : Pickup
{
    protected override void OnPickUp(GameObject ship)
    {
        ship.GetComponent<TimeSlowAbility>().Deactivate();
        ship.GetComponent<MegaLaserAbility>().Deactivate();

        ship.GetComponent<TimeSlowAbility>().enabled = false;
        ship.GetComponent<MegaLaserAbility>().enabled = false;
        ship.GetComponent<SuperDashAbility>().enabled = true;
    }
}
