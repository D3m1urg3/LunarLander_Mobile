using UnityEngine;
using System.Collections;

public class ShipCollisionRegister : MonoBehaviour {
	
	public static bool landingZoneCollision = false;
	public static bool nonLandingZoneCollision = false;
	public static bool laserCollision = false;
	public static bool singularityCollision = false;

	public static int scoreMultiplier;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "LandPad") 
		{
			landingZoneCollision = true;
//			scoreMultiplier = multi.scoreMultiplier;
		}
		else if (col.gameObject.name == "nonLandingZones")
			nonLandingZoneCollision = true;
		else if (col.gameObject.tag == "Laser")
			laserCollision = true;
		else if(col.gameObject.tag == "Singularity")
			singularityCollision = true;
	}

	public static void Restart()
	{
		landingZoneCollision = false;
		nonLandingZoneCollision = false;
		laserCollision = false;
		singularityCollision = false;
	}
	
}
