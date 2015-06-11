using UnityEngine;
using System.Collections;

public class Ship_Shield : MonoBehaviour {

	public void endShieldHitAnim()
	{
		man.shipShieldManager.isShieldHit = false;
		man.colManager.invicible = false;
	}


}
