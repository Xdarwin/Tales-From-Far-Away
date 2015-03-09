using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{

	void OnGUI()
	{
		if(GUI.Button (new Rect(Screen.width/2.5f,Screen.height/4,Screen.width/5,Screen.height/10), " Charger une Partie"))
		{
			Application.LoadLevel(1);

		}

		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2.5f, Screen.width / 5, Screen.height / 10), " Options")) 
		{
				
		}

		if(GUI.Button (new Rect(Screen.width/2.5f,Screen.height/1.8f,Screen.width/5,Screen.height/10), " Quitter le jeu"))
		{
			Application.Quit();
		}
		}
}
