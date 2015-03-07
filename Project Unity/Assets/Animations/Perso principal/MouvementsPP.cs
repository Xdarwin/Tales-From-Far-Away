using UnityEngine;
using System.Collections;

public class MouvementsPP : MonoBehaviour {

    //Variables publiques
    public float gravity;
    public float speed;
    public float speedRun;
    public float speedJump;

    //Variables privées
    private CharacterController controller;
    private Vector3 moveDirection;
    private float deltaTime;
    private Transform characterContent;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0f, 0f, 0f);
        characterContent = transform.Find("Perso Principal FInal 1");
	}




	// Update is called once per frame
	void Update () {
        deltaTime = Time.deltaTime;

        if(controller.isGrounded)
        {
            //On prend les différentes valeurs des axes horizontaux et verticaux et on les met dans le moveDirection (vecteur du déplacement du perso)
            moveDirection.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;


            if (Input.GetKey("left shift")) //Si le perso court.
            {
                moveDirection *= speedRun;
                characterContent.animation.CrossFade("Anim - Courrir", 0.2f);
                WaitForAnimation();
            }
            else
            {
                if (Input.GetButton("Jump")) //Si le perso saute
                {
                    characterContent.animation.CrossFade("Animation - Saut", 0.2f);
                    WaitForAnimation();
                    moveDirection.y += speedJump;
                }
                else
                {
                    characterContent.animation.CrossFade("Anim - Marche"); //Si il ne court ni ne saute et qu'il bouge, alors il marche
                }
            }



            if (!Input.anyKey)
                characterContent.animation.CrossFade("Anim - Idle", 0.2f);
        }

        //Gravity et on bouge le character controller
        moveDirection.y -= gravity * deltaTime; 
        controller.Move(moveDirection * deltaTime);

	}


    //Fonction qui sert à attendre une seconde, soit le temps d'appliquer l'animation. On pourra la changer plus tard avec en paramètres le nombre de secondes
    //si on veut réaliser une animation plus longue.
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1);
    }


}







/* moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
moveDirection = transform.TransformDirection(moveDirection);
//Multiply it by speed.
moveDirection *= speed;
//Jumping
if (Input.GetButton("Jump"))
moveDirection.y = jumpSpeed;
}
//Applying gravity to the controller
moveDirection.y -= gravity * Time.deltaTime;
//Making the character move
controller.Move(moveDirection * Time.deltaTime);*/
