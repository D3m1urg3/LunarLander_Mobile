using UnityEngine;
using System.Collections;

public class LandPad_Lights : MonoBehaviour {

	bool landingAproach = false;

	Animator lights_anim;

	// Use this for initialization
	void Awake () {
		landingAproach = false;

		lights_anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		lights_anim.SetBool ("inLandingZone", landingAproach);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 9)
			landingAproach = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == 9)
			landingAproach = false;
	}

}
