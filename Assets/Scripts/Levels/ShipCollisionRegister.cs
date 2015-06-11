using UnityEngine;
using System.Collections;

public class ShipCollisionRegister : MonoBehaviour {
	
	public bool landingZoneCollision = false;
	public bool nonLandingZoneCollision = false;
	public bool laserCollision = false;
	public bool singularityCollision = false;
	public bool asteroidCollision = false;
	public bool fuelBarrelCollision = false;

	public int scoreMultiplier;
	public int fuel_powerup;

	void Start()
	{
		scoreMultiplier = 0;
	}

	void Update()
	{
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "LandPad") 
		{
			landingZoneCollision = true;

			LanPadValue padValue = col.gameObject.GetComponent<LanPadValue>();
			scoreMultiplier = padValue.scoreMultiplier;

		}
		else if (col.gameObject.tag == "nonLandingZones")
			nonLandingZoneCollision = true;
		else if (col.gameObject.tag == "Laser")
			laserCollision = true;
		else if(col.gameObject.tag == "Singularity")
			singularityCollision = true;
		else if(col.gameObject.tag == "Asteroid")
			asteroidCollision = true;
		else if(col.gameObject.tag == "Fuel_Barrel")
		{
			fuelBarrelCollision = true;
			fuel_powerup = col.gameObject.GetComponent<Fuel_Barrel>().fuel_value;
			col.gameObject.SetActive(false);
		}
	}

	public void Restart()
	{
		landingZoneCollision = false;
		nonLandingZoneCollision = false;
		laserCollision = false;
		singularityCollision = false;
		asteroidCollision = false;
		fuelBarrelCollision = false;
	}
	
}
