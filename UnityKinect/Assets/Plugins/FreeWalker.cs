using UnityEngine;
using System.Collections;

public class FreeWalker : MonoBehaviour {

	double x;
	double y;
	float speed = 5;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(0, 0.3f, 1);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(0, -0.3f, -1);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(1, 0, 0);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(-1, 0, 0);
		}

		if(Input.GetMouseButton(0)){
			x -= Input.GetAxis("Mouse X") *speed*2;
			y += Input.GetAxis("Mouse Y") *speed;
			transform.rotation = Quaternion.Euler((float)y,(float)x,0);
		}
	}
}
