using UnityEngine;
using System.Collections;

public class ShipStatusManager : MonoBehaviour {
    
    public ShipStatus ShipStatus;
    private float dashStartX;

    // Use this for initialization
    void Start()
    {
        this.ShipStatus = ShipStatus.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ShipStatus == ShipStatus.Dashing)
        {
            if(this.GetComponent<Rigidbody2D>().position.x > dashStartX + 2)
            {
                this.ShipStatus = ShipStatus.Recovering;
                var particles = this.GetComponentsInChildren<ParticleSystem>()[1];
                particles.Stop();
                particles.Clear();
            }
        }

        if(this.ShipStatus == ShipStatus.Recovering)
        {
            if(this.GetComponent<Rigidbody2D>().position.x < this.GetComponent<ShipMovement>().MinXPosition)
            {
                this.ShipStatus = ShipStatus.Idle;
            }
        }
    }

    public void StartDash()
    {
        this.ShipStatus = ShipStatus.Dashing;
        this.dashStartX = this.GetComponent<Rigidbody2D>().position.x;
        this.GetComponentsInChildren<ParticleSystem>()[1].Play();
    }
}

public enum ShipStatus
{
    Idle,
    Dashing,
    Recovering
}
