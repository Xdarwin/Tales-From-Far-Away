using UnityEngine;
using System.Collections;

public class Squad : MonoBehaviour {

	protected static Vector3 moveDirection;
	public static float speed;
	private static float delayRotation;
	private static float changeRotation;
	private static float newRotation;

	// Use this for initialization
	void Start () {
		delayRotation = 2;
		speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = Vector3.forward * speed;
		moveDirection = transform.TransformDirection (moveDirection);
		if (changeRotation + delayRotation < Time.fixedTime) {
			newRotation = Random.Range (0, 361);
			changeRotation = Time.fixedTime;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, newRotation, 0),0.5f*Time.deltaTime);
		moveDirection.y -= 1;
		moveDirection = moveDirection * Time.deltaTime;
	}
}
