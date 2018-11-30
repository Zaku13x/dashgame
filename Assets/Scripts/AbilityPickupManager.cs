using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityPickupManager : MonoBehaviour
{
    public List<GameObject> Abilities;
    public float SpawnMinimumSeconds;
    public float SpawnMaximumSeconds;

    private float currentTime = 0;
    private float currentInterval = 0;
    private GameObject ship;

    // Use this for initialization
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        this.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;

        if (this.currentTime > this.currentInterval)
        {
            Spawn();
            StartTimer();
        }
    }

    void StartTimer()
    {
        this.currentInterval = Random.Range(this.SpawnMinimumSeconds, this.SpawnMaximumSeconds);
        this.currentTime = 0;

        var superDashAbility = ship.GetComponent<SuperDashAbility>();
        if (superDashAbility != null)
        {
            if (superDashAbility.IsActive)
            {
                currentInterval /= superDashAbility.SpeedUpScale;
            }
        }
    }

    private void Spawn()
    {
        Vector3 position = this.GetComponent<Transform>().position;

        position.y = position.y + Random.Range(-0.8f, 0.8f);

        var index = Random.Range(0, Abilities.Count);

        GameObject.Instantiate(Abilities[index], position, new Quaternion());
    }
}
