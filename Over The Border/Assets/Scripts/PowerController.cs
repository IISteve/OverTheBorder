using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerController : MonoBehaviour {

    public Slider powerSlider;
    public int LaunchPower;
    bool isfull;
    bool isempty;

    // Use this for initialization
    void Start () {

        LaunchPower = 2;
        isfull = false;
        isempty = true;

    }

    // Update is called once per frame
    void Update(){

        Shooting();

    }

    

    void Shooting()
    {
        if (powerSlider.value == 100)
        {
            isfull = true;
            isempty = false;
        }
        if (powerSlider.value == 0)
        {
            isfull = false;
            isempty = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isfull == true)
            {
                powerSlider.value -= Mathf.Lerp(0f, 100f, LaunchPower * Time.deltaTime);
            }
            if (isempty == true)
            {
                powerSlider.value += Mathf.Lerp(0f, 100f, LaunchPower * Time.deltaTime);
            }
        }
        else
        {
            powerSlider.value = 0;
        }
    }
}