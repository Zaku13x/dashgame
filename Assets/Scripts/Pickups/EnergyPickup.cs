using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EnergyPickup : Pickup
{
    private Slider EnergySlider;

    protected override void OnPickUp(GameObject ship)
    {
        if(EnergySlider.value != EnergySlider.maxValue)
        {
            EnergySlider.value += 1;
        }
    }
    
    public void SetEnergySlider(Slider newEnergySlider)
    {
        this.EnergySlider = newEnergySlider;
    }
}
