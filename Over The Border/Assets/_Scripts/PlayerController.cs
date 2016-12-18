using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public Slider powerSlider;
    float speed = 5;
    public float shootPowerMultiplier = 10;
    public float yshootPowerMultiplier = 30;
    int hittableRaycast;
	public Collider JumpC;
    public Rigidbody Floor;
    bool isShot;
    

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        hittableRaycast = LayerMask.GetMask("HittableRaycast");
        speed = 5;
        rb.useGravity = false;
        JumpC = GetComponent<Collider>();
        isShot = false;
        

    }
	
	// Update is called once per frame
	void Update () {

        ShootingAngle();
        UpdateFloorPos();
        
        
    }

    void FixedUpdate()
    {
        //Bewegung zum Testen
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

        Shooting();

    }

    void ShootingAngle()
    {
        if (isShot == false){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit BGHit;

            if (Physics.Raycast(camRay, out BGHit, 30f, hittableRaycast))
            {
                Vector2 playerToMouse = BGHit.point - transform.position;

                Quaternion angle = Quaternion.LookRotation(playerToMouse);

                rb.MoveRotation(angle);
            }
        }
    }

    void UpdateFloorPos()
    {
        Vector2 PlayerPos = new Vector2(rb.transform.position.x, 2.37f);
        Floor.transform.position = PlayerPos;
    }

    void Shooting()
    {

        Vector2 shootPower = new Vector2(powerSlider.value,Mathf.Abs(rb.rotation.x));

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(shootPower * shootPowerMultiplier);
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "GravityTriggerPlane")
        {
            rb.useGravity = true;
            isShot = true;
        }
    }

}
