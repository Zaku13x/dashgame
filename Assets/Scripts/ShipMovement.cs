using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public float VelocityScale;
    public Vector2 DashVelocity;
    public float RecoveryVelocity;
    public float MinXPosition;
    public float MaxXPosition;
    public float MinYPosition;
    public float MaxYPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var vertAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");

        int vertComponent = 0;
        int horizComponent = 0;

        if (vertAxis > 0)
        {
            vertComponent = 1;
        }
        else if (vertAxis < 0)
        {
            vertComponent = -1;
        }

        var shipStatus = this.GetComponent<ShipStatusManager>().ShipStatus;

        if(shipStatus == ShipStatus.Idle)
        {
            if (horizontalAxis > 0 && this.GetComponent<Rigidbody2D>().position.x < MaxXPosition)
            {
                horizComponent = 1;
            }
            else if (horizontalAxis < 0)
            {
                horizComponent = -1;
            }
        }

        var newVelocity = new Vector2(horizComponent, vertComponent).normalized * VelocityScale;
        var newPosition = this.GetComponent<Rigidbody2D>().position += newVelocity * Time.fixedDeltaTime;
        
        if(newPosition.x < MinXPosition)
        {
            newPosition = new Vector2(MinXPosition, newPosition.y);
            newVelocity = new Vector2(0, newVelocity.y);
        }
        if (newPosition.y < MinYPosition)
        {
            newPosition = new Vector2(newPosition.x, MinYPosition);
            newVelocity = new Vector2(newVelocity.x, 0);
        }
        if (newPosition.y > MaxYPosition)
        {
            newPosition = new Vector2(newPosition.x, MaxYPosition);
            newVelocity = new Vector2(newVelocity.x, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && shipStatus == ShipStatus.Idle)
        {
            this.GetComponent<ShipStatusManager>().StartDash();            
        }

        if(shipStatus == ShipStatus.Dashing)
        {
            newVelocity = DashVelocity;
        }

        if(shipStatus == ShipStatus.Recovering)
        {
            newPosition = new Vector2(newPosition.x - RecoveryVelocity, newPosition.y);
        }        

        this.GetComponent<Rigidbody2D>().velocity = newVelocity;
        this.GetComponent<Rigidbody2D>().position = newPosition;
    }
}
