using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	GameObject ship;
	GameObject engines;
	ShipCollisionRegister ship_collisions;

	Camera cam;

	public float maxLandingSpeed;
	public float maxLandingInclination;

	// Use this for initialization
	void Start () {
		ship = man.shipManager.ship;
		ship_collisions = ship.GetComponent<ShipCollisionRegister> ();
		engines = man.shipManager.engines;
		cam = man.cameraManager.thisCamera;

	}
	
	// Update is called once per frame
	void Update () {

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
		man.textManager.message.text = "GAME OVER";
		man.shipManager.shipDestroyed = true;

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
		man.textManager.message.text = "CONGRATULATIONS!";
		
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase != TouchPhase.Ended)
			{
				//Restart Ship Collision register
				ship_collisions.Restart();
				//Show Score
				//man.uiLeftManager.score += ShipCollisionRegister.scoreMultiplier * man.shipManager.fuel;
				//Restart Level
				man.cameraManager.thisCamera.transform.eulerAngles = Vector3.zero;
				int score = man.shipManager.fuel * man.colManager.ship_collisions.scoreMultiplier;
				if (PlayerPrefs.GetInt("level_" + Application.loadedLevel + "_score",0) < score) PlayerPrefs.SetInt ("level_" + Application.loadedLevel + "_score", score);
				if (PlayerPrefs.GetInt("level_" + Application.loadedLevel + "_score",0) > 0 && PlayerPrefs.GetInt("level_" + Application.loadedLevel+1 + "_fuel",0) < man.shipManager.fuel) PlayerPrefs.SetInt ("level_" + (Application.loadedLevel+1) + "_fuel", man.shipManager.fuel);
				PlayerPrefs.Save ();
				Application.LoadLevel("Selection_Menu");
				//Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
}
