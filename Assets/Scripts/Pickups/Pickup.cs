﻿using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Ship"))
        {
            OnPickUp(coll.gameObject);

            GameObject.Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickUp(GameObject ship);
}
