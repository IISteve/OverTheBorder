using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    public float drag;
    float msSpeed;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        speed = 5;
        drag = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 dragVector = new Vector2(drag, drag);

        rb.AddForce(movement*speed);
        //TODO: "drag" implementieren (Objekt wird langsamer)
        if (msSpeed)
        {
            rb.AddForce(dragVector);
        }
    }
}
