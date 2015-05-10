using UnityEngine;
using System.Collections;

public class ShipCollisionRegister : MonoBehaviour {
	
	public bool landingZoneCollision = false;
	public bool nonLandingZoneCollision = false;
	public bool laserCollision = false;

	public int scoreMultiplier;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "LandPad") 
		{
			landingZoneCollision = true;
			LanPadValue multi = col.gameObject.GetComponent<LanPadValue>();
			scoreMultiplier = multi.scoreMultiplier;
		}
		else if (col.gameObject.name == "nonLandingZones")
			nonLandingZoneCollision = true;
		else if (col.gameObject.name == "Laser")
			laserCollision = true;
	}



}
