﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public Slider powerSlider;
    public float speed;
    public float shootPowerMultiplier;



    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        speed = 5;
        shootPowerMultiplier = 10;


    }
	
	// Update is called once per frame
	void Update () {



	}

    void FixedUpdate()
    {
        //Bewegung zum Testen
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

        // "shooting"
        Vector2 shootPower = new Vector2(powerSlider.value,0);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(shootPower*shootPowerMultiplier);
        }

    }
}
