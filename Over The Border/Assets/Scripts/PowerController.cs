using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerController : MonoBehaviour {

    PlayerController playerController;
    public int LaunchPower;
    bool isfull;
    bool isempty;

    // Use this for initialization
    void Start () {
        playerController = FindObjectOfType<PlayerController>();
        LaunchPower = 2;
        isfull = false;
        isempty = true;

    }

    // Update is called once per frame
    void Update(){

        Shooting();

    }

    
    // Zum Abschiessen vom Object
    void Shooting()
    {
        if (playerController.powerSlider.value == 100)
        {
            isfull = true;
            isempty = false;
        }
        if (playerController.powerSlider.value == 0)
        {
            isfull = false;
            isempty = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isfull == true)
            {
                playerController.powerSlider.value -= Mathf.Lerp(0f, 100f, LaunchPower * Time.deltaTime);
            }
            if (isempty == true)
            {
                playerController.powerSlider.value += Mathf.Lerp(0f, 100f, LaunchPower * Time.deltaTime);
            }
        }
        else
        {
            playerController.powerSlider.value = 0;
        }
    }
}