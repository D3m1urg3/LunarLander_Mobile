using UnityEngine;
using System.Collections;

public class UI_Instruments_Manager : MonoBehaviour {

	public UI_Number [] altitude_digits = new UI_Number[5];
	public UI_Number [] speed_vertical_digits = new UI_Number[5];
	public UI_Number [] speed_horizontal_digits = new UI_Number[5];

	public float refresh_time;
	
	float altitude;
	float mscale = 100f;
	float zeroHeight;

	int speed_vertical;
	int speed_horizontal;

	float timer;

	bool isRed;
	// Use this for initialization
	void Start () {
		Vector3 zeroPosition = man.cameraManager.thisCamera.ScreenToWorldPoint (Vector3.zero);
		
		zeroHeight = zeroPosition.y;
	
		timer = 0.0f;

		foreach (UI_Number digit in altitude_digits)
			digit.DisableRender ();

	}
	
	// Update is called once per frame
	void Update () {


		//Timer to limit sampling
		timer += Time.deltaTime;

		if (timer < refresh_time)
			return;
		else
		{
			timer = 0.0f;
		}


		//Sample altitude and speed
		altitude = (int) ( mscale * (man.shipManager.ship.transform.position.y - zeroHeight) );

		Vector3 velocity = man.shipManager.ship.GetComponent<Rigidbody2D>().velocity;

		speed_vertical = (int)Mathf.Abs( Mathf.Round (100f * velocity.y) );
		speed_horizontal = (int)Mathf.Abs( Mathf.Round (100f * velocity.x) );


		//Check Landing speed
		isRed = !man.colManager.CheckLandingSpeed();

		// Convert values to digits and set sprites
		for(int i=0; i<5; ++i)
		{

			int digit = speed_horizontal%10;
			speed_horizontal_digits[i].number = digit;
			speed_horizontal /= 10;

			digit = speed_vertical%10;
			speed_vertical_digits[i].number = digit;
			speed_vertical_digits[i].bluered = isRed;
			speed_vertical /= 10;

			
		}


	}
}
