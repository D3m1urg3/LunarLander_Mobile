using UnityEngine;
using System.Collections;

public class UI_Instruments_Manager : MonoBehaviour {

	public UI_Number [] altitude_digits = new UI_Number[5];
	public UI_Number [] velocity_digits = new UI_Number[5];


	float altitude;
	float mscale = 100f;
	float zeroHeight;

	int speed;

	// Use this for initialization
	void Start () {
		Vector3 zeroPosition = man.cameraManager.thisCamera.ScreenToWorldPoint (Vector3.zero);
		
		zeroHeight = zeroPosition.y;
	

	}
	
	// Update is called once per frame
	void Update () {

		altitude = (int) ( mscale * (man.shipManager.ship.transform.position.y - zeroHeight) );

		Vector3 velocity = man.shipManager.ship.GetComponent<Rigidbody2D>().velocity;

		speed = (int) Mathf.Round (10f * velocity.y);

		float sum_altitude = 0.0f;
		float sum_velocity = 0.0f;

		
		for( int i = 4; i >= 0; --i)
		{

			if(i != 4)
			{
				sum_altitude += altitude_digits[i+1].number*Mathf.Pow(10.0f,(float)(i+1));
				//sum_velocity += velocity_digits[i+1].number*Mathf.Pow(10.0f,(float)(i+1));

			}
			else
			{
				sum_altitude = 0.0f;
				sum_velocity = 0.0f;
			}
			altitude_digits[i].number = (int) ( (altitude - sum_altitude)/(Mathf.Pow(10.0f,(float)i)) );
			//velocity_digits[i].number = (int) ( (speed - sum_velocity)/(Mathf.Pow(10.0f,(float)i)) );

		}

		float number = speed;
		while (number > 0) 
		{
			float val = number%10;

			print(val);
			number /= 10;
		}

		/*
		Debug.Log ("Altitude: " + altitude);
		Debug.Log ("Altitude digits: ");
		for(int i =0 ; i<5; ++i)
			Debug.Log ("i: " + i + " n: "+ altitude_digits[i].number);
		*/
	}
}
