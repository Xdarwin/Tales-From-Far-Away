﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private float width;
	private int currentHealth;
	public int CurrentHealth
	{
		get {return currentHealth; }
		set{
			if (value<0)
				currentHealth = 0;
			else if (value>maxHealth)
				currentHealth = maxHealth;
			else
				currentHealth = value;
			HandleHealth();
		}
	}
	private float currentXValue; 
	public int maxHealth;
	public Text healthText;
	public Image visualHealth;


	// Use this for initialization
	void Start () 
	{
		width = healthTransform.rect.width*0.91f;
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = (healthTransform.position.x - width)/10;
		CurrentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		HandleHealth ();
	}

	private void HandleHealth(){
		healthText.text = "Health: " + CurrentHealth;
		currentXValue = MapValues (CurrentHealth, 0, maxHealth, minXValue, maxXValue);
		healthTransform.position = new Vector3 (currentXValue, cachedY);

		if (currentHealth > maxHealth / 2) 
			visualHealth.color = new Color32 ((byte)MapValues(CurrentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
		else
			visualHealth.color = new Color32(255, (byte)MapValues(CurrentHealth, 0, maxHealth/2, 0, 255), 0 , 255);
				
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return ((x-inMin)*(outMax-outMin) / (inMax - inMin) + outMin);
	}
}
