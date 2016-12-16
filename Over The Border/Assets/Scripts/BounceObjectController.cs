using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObjectController : MonoBehaviour
{

    public Rigidbody playerRB;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Trampolin()
    {
        Vector2 trampolinPower = new Vector2(20,50);
        playerRB.AddForce(trampolinPower * 10);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            Trampolin();
        }
    }
}