using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	GameObject ship;
	GameObject engines;

	Camera cam;

	public float maxLandingSpeed;
	public float maxLandingInclination;

	// Use this for initialization
	void Start () {
		ship = man.shipManager.ship;
		engines = man.shipManager.engines;
		cam = man.cameraManager.thisCamera;

	}
	
	// Update is called once per frame
	void Update () {

		if (ShipCollisionRegister.nonLandingZoneCollision) 
		{
			man.shipManager.shipDestroyed = true;

			Invoke("DestroyAndRestart",1);

		}
		else if(ShipCollisionRegister.laserCollision)
		{
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if(ShipCollisionRegister.singularityCollision)
        {
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if (ShipCollisionRegister.landingZoneCollision ) {
			if ( CheckLandingSpeed() && CheckLandingInclination() )
			{

				Invoke("GrazAndRestart",1);

			}
			else
			{

				Invoke("DestroyAndRestart",1);

			}

		}

	}

	bool CheckLandingInclination()
	{
		bool goodLandingAngle = false;
		
		if (Vector3.Angle (ship.transform.up, cam.transform.up) < maxLandingInclination)
			goodLandingAngle = true;
		
		return goodLandingAngle;
		
	}
	
	bool CheckLandingSpeed()
	{
		bool goodLandingSpeed = false;
		
		if (Mathf.Abs (ship.GetComponent<Rigidbody2D>().velocity.y) < maxLandingSpeed)
			goodLandingSpeed = true;
		
		return goodLandingSpeed;
	}

	void DestroyAndRestart()
	{
		engines.SetActive (false);
		man.textManager.message.text = "GAME OVER";
		man.shipManager.shipDestroyed = true;

		foreach(Touch touch in Input.touches)
		{
			if(touch.phase != TouchPhase.Ended)
			{
				//Restart Ship Collision register
				ShipCollisionRegister.Restart();
				//Log Score
				PlayerPrefs.SetInt("fuel",man.shipManager.fuel);
				//Restart Level
				man.cameraManager.thisCamera.transform.eulerAngles = Vector3.zero;
				engines.SetActive (true);
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		/*
		if(!Input.anyKeyDown)
		{
			//Time.timeScale = 0f;
		}
		else
		{
			//Restart Ship Collision register
			ShipCollisionRegister.Restart();
			//Time.timeScale = 1;
			//Log Score
			PlayerPrefs.SetInt("fuel",man.shipManager.fuel);
			//Restart Level
			Application.LoadLevel(Application.loadedLevel);
			
		}
		*/
	}

	void GrazAndRestart()
	{
		man.textManager.message.text = "CONGRATULATIONS!";
		
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase != TouchPhase.Ended)
			{
				//Restart Ship Collision register
				ShipCollisionRegister.Restart();
				//Show Score
				//man.uiLeftManager.score += ShipCollisionRegister.scoreMultiplier * man.shipManager.fuel;
				//Log Score
				//PlayerPrefs.SetInt("score",man.uiLeftManager.score);
				PlayerPrefs.SetInt("fuel",man.shipManager.fuel);
				//Restart Level
				man.cameraManager.thisCamera.transform.eulerAngles = Vector3.zero;
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
}
