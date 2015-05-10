using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	GameObject ship;
	Camera cam;
	ShipCollisionRegister shipColReg;

	public float maxLandingSpeed;
	public float maxLandingInclination;

	// Use this for initialization
	void Start () {
		ship = man.shipManager.ship;
		cam = man.cameraManager.thisCamera;
		shipColReg = man.shipManager.ship.GetComponent<ShipCollisionRegister>();
	}
	
	// Update is called once per frame
	void Update () {

		if (shipColReg.nonLandingZoneCollision) 
		{
			man.shipManager.shipDestroyed = true;

			Invoke("DestroyAndRestart",1);

		}
		else if(shipColReg.laserCollision)
		{
			man.shipManager.shipDestroyed = true;
			
			Invoke("DestroyAndRestart",1);
		}
		else if (shipColReg.landingZoneCollision ) {
			if ( CheckLandingSpeed() && CheckLandingInclination() )
			{

				//Show Text
				man.textManager.message.text = "CONGRATULATIONS!";

				if(!Input.anyKeyDown)
				{
					Time.timeScale = 0;
				}
				else
				{
					Time.timeScale = 1;
					//Show Score
					man.uiLeftManager.score += shipColReg.scoreMultiplier * man.shipManager.fuel;
					//Log Score
					PlayerPrefs.SetInt("score",man.uiLeftManager.score);
					PlayerPrefs.SetInt("fuel",man.shipManager.fuel);
					//Restart Level
					Application.LoadLevel(Application.loadedLevel);
				}

			}
			else
			{
				man.shipManager.shipDestroyed = true;
				man.textManager.message.text = "GAME OVER";

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
		man.textManager.message.text = "GAME OVER";
		
		if(!Input.anyKeyDown)
		{
			//Time.timeScale = 0f;
		}
		else
		{
			//Time.timeScale = 1;
			//Log Score
			PlayerPrefs.SetInt("fuel",man.shipManager.fuel);
			//Restart Level
			Application.LoadLevel(Application.loadedLevel);
			
		}
	}


	
}
