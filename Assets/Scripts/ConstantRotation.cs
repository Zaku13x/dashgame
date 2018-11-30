using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().Rotate(new Vector3(0,0,1), 25);
    }
}
