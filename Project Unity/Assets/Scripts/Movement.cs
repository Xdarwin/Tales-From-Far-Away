using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private Vector3 to;
	private Vector3 mouseDirection;
	float sensiverticale = (float)150.0;
	Vector3 angle;
	private float x = (float)0.0;
	private float y = (float)0.0;
	
	// Use this for initialization
	void Start () {
		angle = transform.eulerAngles;
		x = angle.y;
		y = angle.x;
	}
	
	// Update is called once per frame
	void Update () {

			x += Input.GetAxis("Mouse X") * sensiverticale * (float)0.02;
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			transform.rotation = rotation;
	}

	
	static float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
