using UnityEngine;
using System.Collections;

public class ShipCollisionRegister : MonoBehaviour {
	
	public bool landingZoneCollision = false;
	public bool nonLandingZoneCollision = false;
	public bool laserCollision = false;
	public bool singularityCollision = false;

	public int scoreMultiplier;

	void Update()
	{
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "LandPad") 
		{
			landingZoneCollision = true;
			
//			scoreMultiplier = multi.scoreMultiplier;
		}
		else if (col.gameObject.tag == "nonLandingZones")
			nonLandingZoneCollision = true;
		else if (col.gameObject.tag == "Laser")
			laserCollision = true;
		else if(col.gameObject.tag == "Singularity")
			singularityCollision = true;
	}

	public void Restart()
	{
		landingZoneCollision = false;
		nonLandingZoneCollision = false;
		laserCollision = false;
		singularityCollision = false;
	}
	
}
