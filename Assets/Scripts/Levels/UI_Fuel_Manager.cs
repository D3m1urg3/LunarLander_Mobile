using UnityEngine;
using System.Collections;

public class UI_Fuel_Manager : MonoBehaviour {

	//UI Sprites
	public SpriteRenderer [] fuel_level_sprites = new SpriteRenderer[18];
	public SpriteRenderer fuel_warning_sprite;

	int max_fuel;
	int fuel;

	int prev_fuel_level;
	int fuel_level;
	float fuel_per_slice;

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
	}
	
	// Update is called once per frame
	void Update () {

		fuel = man.shipManager.fuel;

		fuel_level = (int) ((float) fuel / fuel_per_slice);

		Debug.Log ("Fuel Level: " + fuel_level);

		if( fuel_level != prev_fuel_level && fuel_level < 17)
		{
			fuel_level_sprites[fuel_level + 1].enabled = false;
			if(fuel_level == 0)
				fuel_level_sprites[0].enabled = false;
		}

	}

	void LateUpdate()
	{
		prev_fuel_level = (int) ((float) fuel / fuel_per_slice);
	}
}
