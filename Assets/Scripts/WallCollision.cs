using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WallCollision : MonoBehaviour
{
    private GameObject ship;
    // Use this for initialization
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(!coll.gameObject.CompareTag("Ship"))
        {
            return;
        }

        var superDashAbility = ship.GetComponent<SuperDashAbility>();
        var statusMan = coll.gameObject.GetComponent<ShipStatusManager>();

        bool isShipInvulnerable = (superDashAbility != null && superDashAbility.IsActive)
            || (statusMan != null && statusMan.ShipStatus == ShipStatus.Dashing);

        if (!isShipInvulnerable)
        {
            SceneManager.LoadScene("test");
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
