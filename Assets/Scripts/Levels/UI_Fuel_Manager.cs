using UnityEngine;
using System.Collections;

public class UI_Fuel_Manager : MonoBehaviour {

	//UI Sprites
	public SpriteRenderer [] fuel_level_sprites = new SpriteRenderer[18];
	public SpriteRenderer fuel_warning_sprite;

	public UI_Number number_0x;
	public UI_Number number_x0;

	public int fuel_reserve_level;

	int max_fuel;
	int fuel;

	int prev_fuel_level;
	int fuel_level;
	float fuel_per_slice;

	int fuel_percent;
	int percent_0x;
	int percent_x0;


	void Awake()
	{
		fuel_warning_sprite.enabled = false;

		foreach (SpriteRenderer sprite in fuel_level_sprites)
			sprite.enabled = true;

	}

	// Use this for initialization
	void Start () {
		max_fuel = man.shipManager.fuel;
		fuel_per_slice = (float)max_fuel / 18;
		prev_fuel_level = (int) ((float) fuel / fuel_per_slice);
		fuel_percent = (int)(fuel / max_fuel) * 100;
		number_0x.bluered = number_x0.bluered = false; //Numbers in blue 
		number_0x.number = number_x0.number = 9;
	}
	
	// Update is called once per frame
	void Update () {

		// Fuel Corona

		fuel = man.shipManager.fuel;

		fuel_level = (int) ((float) fuel / fuel_per_slice);

		//Debug.Log ("Fuel Level: " + fuel_level);

		if(fuel_level <= fuel_reserve_level)
		{
			fuel_warning_sprite.enabled = true; //activate warning ring
			number_0x.bluered = number_x0.bluered = true; //Numbers in red 
		}


		if( fuel_level != prev_fuel_level && fuel_level < 17)
		{
			fuel_level_sprites[fuel_level + 1].enabled = false;
			if(fuel_level == 0)
				fuel_level_sprites[0].enabled = false;
		}

		fuel_percent = (int)(100.0f * (float)fuel / max_fuel) ;

		//Fuel percent
		if(fuel_percent != 100)
		{
			percent_x0 = fuel_percent / 10;
			percent_0x = fuel_percent % 10;

			number_0x.number = percent_0x;
			number_x0.number = percent_x0;
		}
		else
		{
			percent_0x = percent_x0 = 9;
		}

		Debug.Log("fuel percent= " + fuel_percent);
		Debug.Log("percent digits= " + number_x0.number + " " + number_0x.number);

	}

	void LateUpdate()
	{
		prev_fuel_level = (int) ((float) fuel / fuel_per_slice);
	}
}
