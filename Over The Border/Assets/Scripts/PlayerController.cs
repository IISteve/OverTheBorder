﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public Slider powerSlider;
    public float speed = 5;
    public float shootPowerMultiplier = 10;
    public float yshootPowerMultiplier = 30;
    int hittableRaycast;
    float xPower;
	Rigidbody JumpC;



    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        hittableRaycast = LayerMask.GetMask("HittableRaycast");
        speed = 5;
        shootPowerMultiplier = 20;
        yshootPowerMultiplier = 88;
        rb.useGravity = false;
		JumpC = GetComponent<Collider>();

    }
	
	// Update is called once per frame
	void Update () {

        ShootingAngle();
        
    }

    void FixedUpdate()
    {
        //Bewegung zum Testen
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

        xPower = rb.transform.rotation.x;

        // "shooting"
        Vector2 shootPower = new Vector2(powerSlider.value,Mathf.Abs(xPower) * yshootPowerMultiplier);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(shootPower*shootPowerMultiplier);
        }

    }

    void ShootingAngle()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit BGHit;
        
        if (Physics.Raycast(camRay, out BGHit, 30f, hittableRaycast))
        {
            Vector2 playerToMouse = BGHit.point - transform.position;

            Quaternion angle = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(angle);
        }
    }

    void OnTriggerEnter()
    {
        rb.useGravity = true;
		Vector3 JumpPower = new Vector3(50f,100f,0.0f);
		JumpC.addforce = JumpPower;
    }

	void OnTriggerEnter(){
}
