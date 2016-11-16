using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    Vector3 offset;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void LateUpdate () {

        offset = new Vector3(7f, 3f, -10f);
        transform.position = player.transform.position + offset; 

	}
}
