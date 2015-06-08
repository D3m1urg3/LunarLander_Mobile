using UnityEngine;
using System.Collections;

public class LandPad_Smoke : MonoBehaviour {

	bool landingSmoke = false;
	
	Animator lights_anim;
	
	// Use this for initialization
	void Awake () {
		landingSmoke = false;
		
		lights_anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		lights_anim.SetBool ("inLandPadSmokeZone", landingSmoke);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 9)
			landingSmoke = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == 9)
			landingSmoke = false;
	}
}
