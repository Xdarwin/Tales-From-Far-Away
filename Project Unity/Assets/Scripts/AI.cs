using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	protected  Vector3 moveDirection;
	public  float speed;
	private  float delayRotation;
	private  float changeRotation;
	private  float newRotation;
	private  CharacterController controller;
	// Use this for initialization
	void Start () {
		delayRotation = Random.Range (1, 6);
		controller = (CharacterController)GetComponent ("CharacterController");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime % delayRotation == 0) {
			newRotation = Random.Range (0, 361);
		}

		move ();
	}
	private void move(){
		moveDirection = Vector3.forward * speed;
		moveDirection = transform.TransformDirection (moveDirection);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, newRotation, 0),0.5f*Time.deltaTime);
		transform.animation.CrossFade ("run",0.5f*Time.deltaTime);
		moveDirection.y -= 4;
		controller.Move(moveDirection * Time.deltaTime);
	}
	private IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1);
	}
}
