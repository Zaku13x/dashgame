using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    public float Duration;
    public Slider EnergySlider;

    private float currentTimeElapsed;

    public void Activate()
    {
        if(EnergySlider.value == EnergySlider.maxValue)
        {
            EnergySlider.value = 0;
            this.IsActive = true;
            this.currentTimeElapsed = 0;
            OnActivate();
        }
    }

    protected virtual void OnActivate()
    {

    }

    public void Deactivate()
    {
        this.IsActive = false;
        this.currentTimeElapsed = 0;
        OnDeactivate();
    }

    protected virtual void OnDeactivate()
    {

    }

    private bool isActive;
    public bool IsActive
    {
        get
        {
            return this.isActive;
        }
        protected set
        {
            this.isActive = value;
        }
    }

    void Start()
    {
        this.IsActive = false;
        this.currentTimeElapsed = 0;
        OnStart();
    }

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && !this.IsActive)
        {
            Activate();
        }
        else if(this.IsActive)
        {
            this.currentTimeElapsed += Time.deltaTime;

            if(this.currentTimeElapsed >= this.Duration)
            {
                this.Deactivate();
            }
        }
    }

    protected virtual void OnStart()
    {

    }
}
