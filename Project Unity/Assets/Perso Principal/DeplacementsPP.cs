using UnityEngine;
using System.Collections;

public class DeplacementsPP : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveDirection;
    private float deltaTime;
    private Transform characterContent;
    private bool runAnim;


    public float speed;
    public float speedRotate;
    public float speedRun;
    public float gravity;
    public float jumpSpeed;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0f, 0f, 0f);
        characterContent = transform.Find("Perso Principal FInal");
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.deltaTime;


        if(controller.isGrounded)
        {
            //Déplacement avant/arrière
            moveDirection.Set(0f, 0f, Input.GetAxis("Vertical") * speed);
            moveDirection = transform.TransformDirection(moveDirection);


            //Saut et sprint
            if (Input.GetKey("space"))
            {
                moveDirection.y += jumpSpeed;
                characterContent.animation.CrossFade("Anim - Saut", 0.2f);
            }
            else
            {
                if (Input.GetKey("left shift"))
                {
                    moveDirection *= speedRun;
                    characterContent.animation.CrossFade("Anim - Courrir", 0.2f);
                }
                else { characterContent.animation.CrossFade("Anim - Marche", 0.2f); }
            }


            if (!Input.anyKey)
            {
                characterContent.animation.CrossFade("Anim - Idle", 0.2f);
            }



        }


        //Deplacement gauche/droite
        transform.Rotate(0f, Input.GetAxis("Horizontal") * speedRotate * deltaTime, 0f);




        //Gravity
        moveDirection.y -= gravity;

        
        //Deplacement du CC
        controller.Move(moveDirection * deltaTime);


	}
}
