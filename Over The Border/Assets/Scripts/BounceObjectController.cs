using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObjectController : MonoBehaviour
{
    PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Bounce(int x,int y,int multiplier)
    {
        Vector2 BouncePower = new Vector2(x,y);
        playerController.rb.AddForce(BouncePower * multiplier);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Trampolin")
        {
            Bounce(20,50,10);
            Destroy(col.gameObject);
        }

        if(col.tag == "Baloon")
        {
            Bounce(10,60,10);
            Destroy(col.gameObject);
        }
    }
}