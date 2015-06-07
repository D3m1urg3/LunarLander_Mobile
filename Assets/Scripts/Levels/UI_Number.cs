using UnityEngine;
using System.Collections;

public class UI_Number : MonoBehaviour {

	public int number;

	public SpriteRenderer [] number_renders_blue = new SpriteRenderer[10];
	public SpriteRenderer [] number_renders_red = new SpriteRenderer[10];

	public bool bluered; // 0 blue - 1 red

	void Awake()
	{
		number = 0;
	}

	// Use this for initialization
	void Start () {

		foreach (SpriteRenderer sprite in number_renders_blue)
			sprite.enabled = false;

		foreach (SpriteRenderer sprite in number_renders_red)
			sprite.enabled = false;

	}

	// Update is called once per frame
	void Update () {
	
		//Debug.Log ("num: " + number); 

		if (number <= 9) 
		{
			switch(bluered)
			{
			case true: // red

				foreach (SpriteRenderer sprite in number_renders_red)
					sprite.enabled = false;

				number_renders_red[number].enabled = true;
		
				break;

			case false: // blue

				foreach (SpriteRenderer sprite in number_renders_blue)
					sprite.enabled = false;

				number_renders_blue[number].enabled = true;

				break;

			default:
				foreach (SpriteRenderer sprite in number_renders_blue)
					sprite.enabled = false;
				
				number_renders_blue[number].enabled = true;
				break;

			}

		}
		else if( number > 9)
		{
			Debug.LogError(gameObject.name + " class UI_Number: number > 9 out of range!");
			return;
		}


	}

}
