using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncObjects : MonoBehaviour {

    public Rigidbody playerRB;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Trampolin()
    {
        Vector2 trampolinPower = new Vector2(50, 100);
        playerRB.AddForce(trampolinPower);
    }

    void OnTriggerEnter(Collider col)
    {
        Trampolin();
    }
}
