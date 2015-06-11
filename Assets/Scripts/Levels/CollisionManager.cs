using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	GameObject ship;
	GameObject engines;
	ShipCollisionRegister ship_collisions;

	Camera cam;

	public float maxLandingSpeed;
	public float maxLandingInclination;
	public bool invicible;
	public GameObject completedPopup;
	public GameObject failPopup;

	// Use this for initialization
	void Start () {
		completedPopup.SetActive (false);
		failPopup.SetActive (false);
		ship = man.shipManager.ship;
		ship_collisions = ship.GetComponent<ShipCollisionRegister> ();
		engines = man.shipManager.engines;
		cam = man.cameraManager.thisCamera;
	}
	
	// Update is called once per frame
	void Update () {

		if (invicible)
			return;

		if (ship_collisions.nonLandingZoneCollision) 
		{
			
			man.shipManager.shipDestroyed = true;

			Invoke("DestroyAndRestart",1);

		}
		else if(ship_collisions.laserCollision)
		{
			
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if(ship_collisions.singularityCollision)
        {
			
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if(ship_collisions.asteroidCollision)
		{
			
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if(ship_collisions.fuelBarrelCollision)
		{
			ship_collisions.Restart();
			
			man.shipManager.fuel += ship_collisions.fuel_powerup;

			if(man.shipManager.fuel > man.uiFuel.max_fuel)
			{
				man.uiFuel.max_fuel = man.shipManager.fuel;
				man.uiFuel.RestartMaxFuel();
			}
		}
		else if (ship_collisions.landingZoneCollision ) {
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

	public bool CheckLandingInclination()
	{
		bool goodLandingAngle = false;
		
		if (Vector3.Angle (ship.transform.up, cam.transform.up) < maxLandingInclination)
			goodLandingAngle = true;
		
		return goodLandingAngle;
		
	}
	
	public bool CheckLandingSpeed()
	{
		bool goodLandingSpeed = false;

//		Debug.Log (Mathf.Abs (ship.GetComponent<Rigidbody2D> ().velocity.y));
		if (Mathf.Abs (ship.GetComponent<Rigidbody2D>().velocity.y) < maxLandingSpeed)
			goodLandingSpeed = true;
		
		return goodLandingSpeed;
	}

	void DestroyAndRestart()
	{
		//man.textManager.message.text = "GAME OVER";
		failPopup.SetActive (true);
		man.shipManager.shipDestroyed = true;
		man.shipManager.ship.GetComponent<Rigidbody2D> ().isKinematic = true;
		// Add pop-up
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase != TouchPhase.Ended)
			{
				//Restart Ship Collision register
				ship_collisions.Restart();
				//Restart Level
				man.cameraManager.thisCamera.transform.eulerAngles = Vector3.zero;
				//Application.LoadLevel(Application.loadedLevel);
				Application.LoadLevel("Selection_Menu");
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
		//man.textManager.message.text = "CONGRATULATIONS!";
		
		//foreach(Touch touch in Input.touches)
		//{
		//	if(touch.phase != TouchPhase.Ended)
		//	{
		//Restart Ship Collision register
		//Show Score
		//man.uiLeftManager.score += ShipCollisionRegister.scoreMultiplier * man.shipManager.fuel;
		//Restart Level
		// something something camera
		man.cameraManager.thisCamera.transform.eulerAngles = Vector3.zero;
		man.shipManager.ship.GetComponent<Rigidbody2D> ().isKinematic = true;

		//set up popup
		foreach (Transform child in completedPopup.transform.Find ("Level")) {
			if (child.name == (Application.loadedLevel+1).ToString()) child.gameObject.SetActive(true);
			else child.gameObject.SetActive(false);
		}
		completedPopup.SetActive (true);
		// save score
		int score = man.shipManager.fuel * man.colManager.ship_collisions.scoreMultiplier;
		if (PlayerPrefs.GetInt("level_" + Application.loadedLevel + "_score",0) < score) PlayerPrefs.SetInt ("level_" + Application.loadedLevel + "_score", score);
		if (PlayerPrefs.GetInt("level_" + Application.loadedLevel + "_score",0) > 0 && PlayerPrefs.GetInt("level_" + Application.loadedLevel+1 + "_fuel",0) < man.shipManager.fuel) PlayerPrefs.SetInt ("level_" + (Application.loadedLevel+1) + "_fuel", man.shipManager.fuel);
		PlayerPrefs.Save ();
		// restart something
		ship_collisions.Restart();
		//Application.LoadLevel("Selection_Menu");
		//Application.LoadLevel(Application.loadedLevel);
		//	}
		//}
	}
	
}
