using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour
{
    public float Speed;

    private GameObject ship;

    // Use this for initialization
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        var newVelocity = new Vector2(this.Speed * -1, 0);

        var superDashAbility = ship.GetComponent<SuperDashAbility>();
        if (superDashAbility != null)
        {
            if (superDashAbility.IsActive)
            {
                newVelocity *= superDashAbility.SpeedUpScale;
            }
        }

        this.GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
}
